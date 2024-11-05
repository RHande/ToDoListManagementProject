using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Models.Dtos.Categories.Request;
using ToDoList.Service.Services.Abstracts;

namespace ToDoList.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]

public class CategoryController(ICategoryService categoryService) : ControllerBase
{
    [HttpGet("getall")]
    public IActionResult GetAll()
    {
        var result = categoryService.GetAll();
        return Ok(result);
    }
    
    [HttpPost("Add")]
    public IActionResult Add([FromBody]AddCategoryRequestDto dto)
    {
        var result = categoryService.Add(dto);
        return Ok(result);
    }
    
    [HttpGet("getbyid/{id:int}")]
    public IActionResult GetById([FromRoute]int id)
    {
        var result = categoryService.GetById(id);
        return Ok(result);
    }
    
    [HttpPut("update")]
    public IActionResult Update([FromBody] UpdateCategoryRequestDto dto)
    {
        var result = categoryService.Update(dto);
        return Ok(result);
    }
    
    [HttpDelete("delete/{id:int}")]
    public IActionResult Delete([FromRoute]int id)
    {
        var result = categoryService.Delete(id);
        return Ok(result);
    }
    
    [HttpGet("getbyname/{name}")]
    public IActionResult GetByName([FromRoute]string name)
    {
        var result = categoryService.GetByName(name);
        return Ok(result);
    }
    
    
    [HttpGet("getallbynamecontains/{name}")]
    public IActionResult GetAllByNameContains([FromRoute]string name)
    {
        var result = categoryService.GetAllByNameContains(name);
        return Ok(result);
    }
    
    [HttpGet("getalltodobycategoryname/{name}")]
    public IActionResult GetAllToDoByCategoryName([FromRoute]string name)
    {
        var result = categoryService.GetAllToDoByCategoryName(name);
        return Ok(result);
    }
    
    [HttpGet("getalltodobycategoryid/{id:int}")]
    public IActionResult GetAllToDoByCategoryId([FromRoute]int id)
    {
        var result = categoryService.GetAllToDoByCategoryId(id);
        return Ok(result);
    }
    
}