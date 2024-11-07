using ToDoList.Models.Dtos.Tokens;
using ToDoList.Models.Entities;

namespace ToDoList.Service.Services.Abstracts;

public interface IJwtService
{
    Task<TokenResponseDto> CreateToken(User user);
}