using Core.Entities;
using ToDoList.Models.Dtos.Categories.Request;
using ToDoList.Models.Dtos.Categories.Response;

namespace ToDoList.Service.Services.Abstracts;

public interface ICategoryService
{
    ReturnModel<CategoryResponseDto> Add(AddCategoryRequestDto dto);
    ReturnModel<List<CategoryResponseDto>> GetAll();
    ReturnModel<CategoryResponseDto> GetById(int id);
    ReturnModel<CategoryResponseDto> Update(UpdateCategoryRequestDto dto);
    ReturnModel<string> Delete(int id);
    ReturnModel<List<CategoryResponseDto>> GetByName(string name);
    ReturnModel<List<CategoryResponseDto>> GetAllByNameContains(string text);
    ReturnModel<List<CategoryWithToDoResponseDto>> GetAllToDoByCategoryName(string name);
    ReturnModel<List<CategoryWithToDoResponseDto>> GetAllToDoByCategoryId(int id);
}