using Microsoft.Extensions.Configuration;
using QuoteManager.Application.Interfaces;
using QuoteManager.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using QuoteManager.Core.Entities;
using QuoteManager.Application.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace QuoteManager.Application.Services
{
    public class AuthService(QuoteDbContext context, IConfiguration config) : IAuthService
    {
        private readonly PasswordHasher<User> _hasher = new();

        public async Task<AuthResponseDto?> RegisterAsync(RegisterUserDto dto)
        {
            if (await context.Users.AnyAsync(u => u.Email == dto.Email))
                return null;

            var user = new User
            {
                Id = Guid.NewGuid(),
                Email = dto.Email,
                PasswordHash = "",
                Role = dto.Role
            };

            user.PasswordHash = _hasher.HashPassword(user, dto.Password);

            context.Users.Add(user);
            await context.SaveChangesAsync();

            return GenerateToken(user);
        }

        public async Task<AuthResponseDto?> LoginAsync(LoginUserDto dto)
        {
            var user = await context.Users.FirstOrDefaultAsync(u => u.Email == dto.Email);
            if (user == null) 
                return null;

            var result = _hasher.VerifyHashedPassword(user, user.PasswordHash, dto.Password);
            if (result != PasswordVerificationResult.Success)
                return null;

            return GenerateToken(user);
        }

        private AuthResponseDto GenerateToken(User user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            };

            var token = new JwtSecurityToken(
                issuer: config["Jwt:Issuer"],
                audience: config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(3),
                signingCredentials: creds
            );

            return new AuthResponseDto
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Email = user.Email,
                Role = user.Role
            };
        }
    }
}
