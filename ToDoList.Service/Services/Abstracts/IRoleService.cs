using ToDoList.Models.Dtos.Users.Request;

namespace ToDoList.Service.Services.Abstracts;

public interface IRoleService
{
    Task<string> AddRoleToUser(RoleAddToUserRequestDto dto);
    Task<List<string>> GetAllRolesByUserId(string userId);
    Task<string> AddRoleAsync(string roleName);
}