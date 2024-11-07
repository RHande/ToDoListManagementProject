using Core.Exceptions;
using Microsoft.AspNetCore.Identity;
using ToDoList.Models.Dtos.Users.Request;
using ToDoList.Models.Entities;
using ToDoList.Service.Services.Abstracts;

namespace ToDoList.Service.Services.Concretes;

public sealed class RoleService (UserManager<User> userManager, RoleManager<IdentityRole> roleManager) : IRoleService
{
    public async Task<string> AddRoleToUser(RoleAddToUserRequestDto dto)
    {
        //Role kontrolü:
        var role = await roleManager.FindByNameAsync(dto.RoleName);
        RoleCheck(role);
        
        //User kontrolü:
        var user = await userManager.FindByIdAsync(dto.UserId);
        UserCheck(user);
        
        //Role ekleme işlemi:
        var addRoleToUser = await userManager.AddToRoleAsync(user, dto.RoleName);
        if (!addRoleToUser.Succeeded)
        {
            throw new BusinessException(addRoleToUser.Errors.First().Description);
        }
        return "Role added to user : " + dto.RoleName;
    }

    public async Task<List<string>> GetAllRolesByUserId(string userId)
    {
        var user = await userManager.FindByIdAsync(userId);
        var roles = await userManager.GetRolesAsync(user);
        return roles.ToList();
    }

    public async Task<string> AddRoleAsync(string roleName)
    {
        var role = new IdentityRole { Name = roleName };
        var chechRoleName = await roleManager.FindByNameAsync(roleName);
        if (chechRoleName is not null)
        {
            throw new BusinessException("Role already exists");
        }

        var result = await roleManager.CreateAsync(role);
        if (!result.Succeeded)
        {
            throw new BusinessException(result.Errors.First().Description);
        }
        return "Role added : " + roleName;
    }




    private void UserCheck(User? user)
    {
        if (user is null)
        {
            throw new NotFoundException("User not found");
        }
    }
    
    private void RoleCheck(IdentityRole? role)
    {
        if (role is null)
        {
            throw new BusinessException("Role not found");
        }
    }
}