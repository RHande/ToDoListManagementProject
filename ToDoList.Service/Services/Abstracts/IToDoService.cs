using Core.Entities;
using ToDoList.Models.Dtos.ToDos.Request;
using ToDoList.Models.Dtos.ToDos.Response;

namespace ToDoList.Service.Services.Abstracts;

public interface IToDoService
{
    Task<ReturnModel<ToDoResponseDto>> Add(AddToDoRequestDto dto, string userId);
    ReturnModel<List<ToDoResponseDto>> GetAll();
    ReturnModel<ToDoResponseDto> Update(UpdateToDoRequestDto dto, string userId);
    ReturnModel<string> Delete(Guid id);
    ReturnModel<ToDoResponseDto> GetById(Guid id);
    ReturnModel<List<ToDoResponseDto>> GetAllByCategoryId(int id);
    ReturnModel<List<ToDoResponseDto>> GetAllByTitleContains(string text);
    ReturnModel<List<ToDoResponseDto>> GetAllToDoByCompleted(bool completed, string userId);
    ReturnModel<List<ToDoResponseDto>> GetAllToDoByUserId(string userId);
    ReturnModel<List<ToDoResponseDto>> GetFilteredOwnToDos(string userId, ToDoFilterRequestDto filters);
    
}