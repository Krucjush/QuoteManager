﻿using QuoteManager.Application.DTOs;

namespace QuoteManager.Application.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResponseDto?> RegisterAsync(RegisterUserDto dto);
        Task<AuthResponseDto?> LoginAsync(LoginUserDto dto);
    }
}
