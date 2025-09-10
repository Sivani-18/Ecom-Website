using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using dotnetapp.DTOs;
using dotnetapp.Data;
namespace dotnetapp.Services
{

public interface IAuthService
{
    Task<AuthResponseDto> LoginAsync(LoginRequestDto request);
    Task<AuthResponseDto> RegisterAsync(RegisterRequestDto request);
    Task<string> GenerateJwtTokenAsync(User user);
    Task<bool> ValidateTokenAsync(string token);
}
}