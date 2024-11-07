using AutoMapper;
using Core.Entities;
using ToDoList.Models.Dtos.ToDos.Request;
using ToDoList.Models.Dtos.ToDos.Response;
using ToDoList.Models.Entities;
using ToDoList.Models.Enums;
using ToDoList.Repository.Repositories.Abstracts;
using ToDoList.Service.Constants;
using ToDoList.Service.Rules;
using ToDoList.Service.Services.Abstracts;

namespace ToDoList.Service.Services.Concretes;

public class ToDoService (IToDoRepository toDoRepository, ToDoBusinessRules toDoBusinessRules, IMapper mapper) : IToDoService
{
    public async Task<ReturnModel<ToDoResponseDto>> Add(AddToDoRequestDto dto, string userId)
    {
        toDoBusinessRules.ToDoTitleIsUnique(dto.Title);
        ToDo createdToDo = mapper.Map<ToDo>(dto);
        createdToDo.Id = Guid.NewGuid();
        createdToDo.UserId = userId;
        ToDo toDo = toDoRepository.Add(createdToDo);
        ToDoResponseDto response = mapper.Map<ToDoResponseDto>(toDo);
        return new ReturnModel<ToDoResponseDto>()
        {
            Data = response,
            Message = Messages.ToDoAddedMessage,
            Status = 200,
            Success = true
        };
    }

    public ReturnModel<List<ToDoResponseDto>> GetAll()
    {
        var todos = toDoRepository.GetAll();
        List<ToDoResponseDto> responses = mapper.Map<List<ToDoResponseDto>>(todos);
        return new ReturnModel<List<ToDoResponseDto>>()
        {
            Data = responses,
            Message = Messages.ToDoFetchedMessage,
            Status = 200,
            Success = true
        };
        
    }

    public ReturnModel<ToDoResponseDto> Update(UpdateToDoRequestDto dto, string userId)
    {
        toDoBusinessRules.ToDoIsPresent(dto.Id);
        ToDo toDo = toDoRepository.GetById(dto.Id);
        toDoBusinessRules.IdIsMatched(dto.Id, userId);
            toDo.Title = dto.Title;
            toDo.Description = dto.Description;
            toDo.Completed = (bool)dto.Completed!;
            toDo.Priority = (Priority)dto.Priority!;
            toDo.EndDate = (DateTime)dto.EndDate!;
            toDoRepository.Update(toDo);
        ToDoResponseDto response = mapper.Map<ToDoResponseDto>(toDo);
        return new ReturnModel<ToDoResponseDto>()
        {
            Data = response,
            Message = Messages.ToDoUpdatedMessage,
            Status = 200,
            Success = true
        };
        
    }

    public ReturnModel<string> Delete(Guid id)
    {
        toDoBusinessRules.ToDoIsPresent(id);
        ToDo toDo = toDoRepository.GetById(id);
        toDoRepository.Delete(toDo);
        return new ReturnModel<string>()
        {
            Data = Messages.ToDoDeletedMessage,
            Message = Messages.ToDoDeletedMessage,
            Status = 200,
            Success = true
        };
    }

    public ReturnModel<ToDoResponseDto> GetById(Guid id)
    {
        toDoBusinessRules.ToDoIsPresent(id);
        var todo = toDoRepository.GetById(id);
        ToDoResponseDto response = mapper.Map<ToDoResponseDto>(todo);
        return new ReturnModel<ToDoResponseDto>()
        {
            Data = response,
            Message = Messages.ToDoFetchedMessage,
            Status = 200,
            Success = true
        };
    }

    public ReturnModel<List<ToDoResponseDto>> GetAllByCategoryId(int id)
    {
        List<ToDo> todos = toDoRepository.GetAll(x=>x.CategoryId==id);
        List<ToDoResponseDto> responses = mapper.Map<List<ToDoResponseDto>>(todos);
        return new ReturnModel<List<ToDoResponseDto>>()
        {
            Data = responses,
            Message = Messages.ToDoFetchedMessage,
            Status = 200,
            Success = true
        };
    }

    public ReturnModel<List<ToDoResponseDto>> GetAllByTitleContains(string text)
    {
        List<ToDo> todos = toDoRepository.GetAll(x=>x.Title.Contains(text));
        List<ToDoResponseDto> responses = mapper.Map<List<ToDoResponseDto>>(todos);
        return new ReturnModel<List<ToDoResponseDto>>()
        {
            Data = responses,
            Message = Messages.ToDoFetchedMessage,
            Status = 200,
            Success = true
        };
    }

    public ReturnModel<List<ToDoResponseDto>> GetAllToDoByCompleted(bool completed, string userId)
    {
        List<ToDo> todos = toDoRepository.GetAll(x=>x.Completed==completed && x.UserId==userId);
        List<ToDoResponseDto> responses = mapper.Map<List<ToDoResponseDto>>(todos);
        return new ReturnModel<List<ToDoResponseDto>>()
        {
            Data = responses,
            Message = Messages.ToDoFetchedMessage,
            Status = 200,
            Success = true
        };
    }

    public ReturnModel<List<ToDoResponseDto>> GetAllToDoByUserId(string userId)
    {
        List<ToDo> todos = toDoRepository.GetAll(x=>x.UserId==userId);
        List<ToDoResponseDto> responses = mapper.Map<List<ToDoResponseDto>>(todos);
        return new ReturnModel<List<ToDoResponseDto>>()
        {
            Data = responses,
            Message = Messages.ToDoFetchedMessage,
            Status = 200,
            Success = true
        };
    }

    //Dinamic Search
    public ReturnModel<List<ToDoResponseDto>> GetFilteredOwnToDos(string userId, ToDoFilterRequestDto filters)
    {
        IQueryable<ToDo> query = toDoBusinessRules.FilterForOwnToDos(filters, userId);
        List<ToDo> todos = query.ToList();
        List<ToDoResponseDto> responses = mapper.Map<List<ToDoResponseDto>>(todos);
        return new ReturnModel<List<ToDoResponseDto>>()
        {
            Data = responses,
            Message = Messages.ToDoFetchedMessage,
            Status = 200,
            Success = true
        };
    }
}