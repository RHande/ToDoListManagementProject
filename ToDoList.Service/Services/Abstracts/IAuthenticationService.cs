using ToDoList.Models.Dtos.Tokens;
using ToDoList.Models.Dtos.Users.Request;

namespace ToDoList.Service.Services.Abstracts;

public interface IAuthenticationService
{
    Task<TokenResponseDto> RegisterByUserAsync(RegisterRequestDto registerDto);
    Task<TokenResponseDto> LoginByUserAsync(LoginRequestDto loginDto);
}