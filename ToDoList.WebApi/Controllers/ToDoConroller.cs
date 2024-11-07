using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Models.Dtos.ToDos.Request;
using ToDoList.Models.Dtos.ToDos.Response;
using ToDoList.Models.Enums;
using ToDoList.Service.Services.Abstracts;

namespace ToDoList.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]


public class ToDoConroller (IToDoService toDoService): ControllerBase
{
    [HttpGet("getall")]
    public IActionResult GetAll()
    {
        var result = toDoService.GetAll();
        return Ok(result);
    }
    
    [HttpPost("add")]
    public async Task<IActionResult> Add([FromBody]AddToDoRequestDto dto)
    {
        string? userId = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
        if (userId == null)
        {
            return Unauthorized("User ID not found in token.");
        }
        var result = await toDoService.Add(dto, userId);
        return Ok(result);
    }
    
    [HttpGet("getbyid/{id:guid}")]
    public IActionResult GetById([FromRoute]Guid id)
    {
        var result = toDoService.GetById(id);
        return Ok(result);
    }
    
    [HttpPut("update")]
    public IActionResult Update([FromBody] UpdateToDoRequestDto dto)
    {
        string? userId = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
        if (userId == null)
        {
            return Unauthorized("User ID not found in token.");
        }
        var result = toDoService.Update(dto, userId);
        return Ok(result);
    }
    
    [HttpDelete("delete/{id:guid}")]
    public IActionResult Delete([FromRoute]Guid id)
    {
        var result = toDoService.Delete(id);
        return Ok(result);
    }
    
    [HttpGet("getallbycategoryid/{id:int}")]
    public IActionResult GetAllByCategoryId([FromRoute]int id)
    {
        var result = toDoService.GetAllByCategoryId(id);
        return Ok(result);
    }
    
    [HttpGet("getallbytitlecontains/{text}")]
    public IActionResult GetAllByTitleContains([FromRoute]string text)
    {
        var result = toDoService.GetAllByTitleContains(text);
        return Ok(result);
    }
    
    [HttpGet("getalltodobycompleted/{completed}")]
    public IActionResult GetAllToDoByCompleted([FromRoute]bool completed)
    {
        string? userId = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
        if (userId == null)
        {
            return Unauthorized("User ID not found in token.");
        }
        var result = toDoService.GetAllToDoByCompleted(completed, userId);
        return Ok(result);
    }
    
    [HttpGet("getalltodobyuserid")]
    public IActionResult GetAllToDoByUserId()
    {
        string? userId = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
        if (userId == null)
        {
            return Unauthorized("User ID not found in token.");
        }
        var result = toDoService.GetAllToDoByUserId(userId);
        return Ok(result);
    }
    
    
    //Dinamik filtreleme yapılabilen metod
    [HttpPost("getfilteredowntodos")]
    public IActionResult GetFilteredOwnToDos([FromBody] ToDoFilterRequestDto filters)
    {
        string? userId = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
        if (userId == null)
        {
            return Unauthorized("User ID not found in token.");
        }
        
        var result = toDoService.GetFilteredOwnToDos(userId, filters);
        return Ok(result);
    }
}