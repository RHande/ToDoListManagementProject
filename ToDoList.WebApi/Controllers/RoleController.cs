using Microsoft.AspNetCore.Mvc;
using ToDoList.Models.Dtos.Users.Request;
using ToDoList.Service.Services.Abstracts;

namespace ToDoList.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]

public class RoleController (IRoleService roleService) : ControllerBase
{
    [HttpPost("addRoleToUser")]
    public async Task<IActionResult> AddRoleToUser([FromBody]RoleAddToUserRequestDto dto)
    {
        var result = await roleService.AddRoleToUser(dto);
        return Ok(result);
    }
    
    
    [HttpGet("getAllRolesByUserId")]
    public async Task<IActionResult> GetAllRolesByUserId([FromQuery]string userId)
    {
        var result = await roleService.GetAllRolesByUserId(userId);
        return Ok(result);
    }
    
    
    [HttpPost("addRole")]
    public async Task<IActionResult> AddRoleAsync([FromBody]string roleName)
    {
        var result = await roleService.AddRoleAsync(roleName);
        return Ok(result);
    }
}