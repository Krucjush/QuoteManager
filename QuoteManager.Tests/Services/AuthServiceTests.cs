using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Moq;
using QuoteManager.Application.DTOs;
using QuoteManager.Application.Services;
using QuoteManager.Core.Entities;
using QuoteManager.Core.Enums;
using QuoteManager.Infrastructure.Data;

namespace QuoteManager.Tests.Services
{
    public class AuthServiceTests
    {
        private readonly AuthService _authService;
        private readonly QuoteDbContext _dbContext;
        private readonly Mock<IPasswordHasher<User>> _hasherMock = new();
        private readonly IConfiguration _config;

        public AuthServiceTests()
        {
            var options = new DbContextOptionsBuilder<QuoteDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            _dbContext = new QuoteDbContext(options);

            var inMemorySettings = new Dictionary<string, string>
            {
            {"Jwt:Key", "THIS_IS_A_SUPER_SECRET_KEY_1234567890123456"},
            {"Jwt:Issuer", "TestIssuer"},
            {"Jwt:Audience", "TestAudience"}
            };
            _config = new ConfigurationBuilder().AddInMemoryCollection(inMemorySettings!).Build();

            _authService = new AuthService(_dbContext, _config);
        }

        [Fact]
        public async Task RegisterAsync_Should_Create_User_And_Return_Token()
        {
            var dto = new RegisterUserDto { Email = "test@example.com", Password = "pass123", Role = UserRole.Customer };

            _hasherMock.Setup(h => h.HashPassword(It.IsAny<User>(), dto.Password)).Returns("hashed");

            var result = await _authService.RegisterAsync(dto);

            Assert.NotNull(result);
            Assert.Equal(dto.Email, result.Email);
            Assert.Equal(dto.Role, result.Role);
            Assert.False(string.IsNullOrEmpty(result.Token));
        }

        [Fact]
        public async Task RegisterAsync_Should_Return_Null_If_Email_Exists()
        {
            var user = new User { Id = Guid.NewGuid(), Email = "exists@example.com", PasswordHash = "hash", Role = UserRole.Customer };
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();

            var dto = new RegisterUserDto { Email = "exists@example.com", Password = "pass", Role = UserRole.Customer };

            var result = await _authService.RegisterAsync(dto);

            Assert.Null(result);
        }

        [Fact]
        public async Task LoginAsync_Should_Return_Token_If_Credentials_Valid()
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                Email = "login@example.com",
                Role = UserRole.Customer,
                PasswordHash = ""
            };

            var hasher = new PasswordHasher<User>();
            user.PasswordHash = hasher.HashPassword(user, "password");

            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();

            var dto = new LoginUserDto
            {
                Email = "login@example.com",
                Password = "password"
            };

            var result = await _authService.LoginAsync(dto);

            Assert.NotNull(result);
            Assert.Equal(dto.Email, result.Email);
            Assert.False(string.IsNullOrEmpty(result.Token));
        }

        [Fact]
        public async Task LoginAsync_Should_Return_Null_If_User_Not_Found()
        {
            var dto = new LoginUserDto { Email = "nouser@example.com", Password = "password" };

            var result = await _authService.LoginAsync(dto);

            Assert.Null(result);
        }

        [Fact]
        public async Task LoginAsync_Should_Return_Null_If_Password_Wrong()
        {
            // Arrange
            var user = new User
            {
                Id = Guid.NewGuid(),
                Email = "wrongpass@example.com",
                Role = UserRole.Customer,
                PasswordHash = ""
            };

            var hasher = new PasswordHasher<User>();
            user.PasswordHash = hasher.HashPassword(user, "correct-password");

            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();

            var dto = new LoginUserDto
            {
                Email = "wrongpass@example.com",
                Password = "wrong-password"
            };

            // Act
            var result = await _authService.LoginAsync(dto);

            // Assert
            Assert.Null(result);
        }
    }
}
