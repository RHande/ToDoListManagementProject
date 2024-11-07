using Core.Exceptions;
using Microsoft.AspNetCore.Identity;
using ToDoList.Models.Dtos.Users.Request;
using ToDoList.Models.Entities;
using ToDoList.Service.Services.Abstracts;

namespace ToDoList.Service.Services.Concretes;

public class UserService(UserManager<User> userManager) : IUserService
{
    public async Task<User> CreateUserAsync(RegisterRequestDto registerRequestDto)
    {
        
        User user = new User()
        {
            Email = registerRequestDto.Email,
            UserName = registerRequestDto.Username,
            BirthDate = registerRequestDto.BirthDate,
        };

        var result = await userManager.CreateAsync(user, registerRequestDto.Password);
        if (!result.Succeeded)
        {
            throw new Exception("User could not be created");
        }
        var role = await userManager.AddToRoleAsync(user, "User");
        if (!role.Succeeded)
        {
            throw new BusinessException(role.Errors.First().Description);
        }
        
        return user;
    }

    public async Task<User> GetByEmailAsync(string email)
    {
        var user = await userManager.FindByEmailAsync(email);
        if (user is null)
        {
            throw new NotFoundException("User not found");
        }

        return user;
    }

    public async Task<User> LoginAsync(LoginRequestDto dto)
    {
        var userExist = await userManager.FindByEmailAsync(dto.Email);
        UserIsPresent(userExist);
        
        var result = await userManager.CheckPasswordAsync(userExist, dto.Password);
        if (!result)
        {
            throw new Exception("Password is wrong");
        }
        
        return userExist;
    }

    public async Task<string> DeleteAsync(string id)
    {
        var user = await userManager.FindByIdAsync(id);
        UserIsPresent(user);
        await userManager.DeleteAsync(user);
        return "User deleted successfully";
    }

    public async Task<User> UpdateAsync(string id, UpdateUserRequestDto dto)
    {
        var user = await userManager.FindByIdAsync(id);
        UserIsPresent(user);
        
        user.UserName = dto.Username;
        user.BirthDate = dto.BirthDate;
        
        var result = await userManager.UpdateAsync(user);
        if (!result.Succeeded)
        {
            throw new BusinessException(result.Errors.First().Description);
        }

        return user;
    }

    public async Task<string> ChangePasswordAsync(string id, ChangePasswordRequestDto dto)
    {
        var user = await userManager.FindByIdAsync(id);
        UserIsPresent(user);
        
        var result = await userManager.ChangePasswordAsync(user, dto.OldPassword, dto.NewPassword);
        if (!result.Succeeded)
        {
            throw new BusinessException(result.Errors.First().Description);
        }
        
        return "Password changed successfully";
    }

    private void UserIsPresent(User? user)
    {
        if (user is null)
        {
            throw new NotFoundException("User not found");
        }
    }
}