using QuoteManager.Core.Enums;

namespace QuoteManager.Application.DTOs
{
    public class RegisterUserDto
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
        public UserRole Role { get; set; } = UserRole.Customer;
    }
}
