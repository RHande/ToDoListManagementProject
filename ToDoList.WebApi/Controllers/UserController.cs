using Microsoft.AspNetCore.Mvc;
using ToDoList.Models.Dtos.Users.Request;
using ToDoList.Models.Entities;
using ToDoList.Service.Services.Abstracts;

namespace ToDoList.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]

public class UserController(IUserService userService , IAuthenticationService authenticationService) : ControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> CreateUser([FromBody]RegisterRequestDto dto)
    {
        var result = await authenticationService.RegisterByUserAsync(dto);
        return Ok(result);
    }
    
    [HttpGet("getbyemail")]
    public async Task<IActionResult> GetUserByEmail([FromQuery]string email)
    {
        User user = await userService.GetByEmailAsync(email);
        return Ok(user);
    }
    
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody]LoginRequestDto dto)
    {
        var result = await authenticationService.LoginByUserAsync(dto);
        return Ok(result);
    }

    [HttpDelete("delete")]
    public async Task<IActionResult> Delete([FromQuery] string id)
    {
        var result = await userService.DeleteAsync(id);
        return Ok(result);
    }
    
    [HttpPut("update")]
    public async Task<IActionResult> Update([FromQuery] string id, [FromBody] UpdateUserRequestDto dto)
    {
        var result = await userService.UpdateAsync(id, dto);
        return Ok(result);
    }
    
    [HttpPut("changepassword")]
    public async Task<IActionResult> ChangePassword(string id, ChangePasswordRequestDto dto)
    {
        var result = await userService.ChangePasswordAsync(id, dto);
        return Ok(result);
    }
}