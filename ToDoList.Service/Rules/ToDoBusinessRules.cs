using AutoMapper;
using Core.Exceptions;
using ToDoList.Models.Dtos.ToDos.Request;
using ToDoList.Models.Dtos.ToDos.Response;
using ToDoList.Models.Entities;
using ToDoList.Models.Enums;
using ToDoList.Repository.Repositories.Abstracts;
using ToDoList.Service.Constants;

namespace ToDoList.Service.Rules;

public class ToDoBusinessRules (IToDoRepository _toDoRepository)
{
    public void ToDoIsPresent(Guid id)
    {
        var toDo = _toDoRepository.GetById(id);
        if (toDo == null)
        {
            throw new NotFoundException(Messages.ToDoIsNotPresentMessage(id));
        }
    }
    
    public void ToDoTitleIsUnique(string title)
    {
        var toDo = _toDoRepository.GetAll(x => x.Title == title);
        if (toDo.Count > 0)
        {
            throw new BusinessException(Messages.ToDoTitleIsUniqueMessage);
        }
    }
    
    public void IdIsMatched(Guid id, string userId)
    {
        var toDo = _toDoRepository.GetById(id);
        if (toDo.UserId != userId)
        {
            throw new ForbiddenException("You are not authorized to update this ToDo");
        }
    }

    public IQueryable<ToDo> FilterForOwnToDos(ToDoFilterRequestDto filters, string userId)
    {
        var query = _toDoRepository.GetAll(x => x.UserId == userId).AsQueryable();
        if (filters.Title != null)
        {
            query = query.Where(x => x.Title.Contains(filters.Title));
        }
        if (filters.Completed != null)
        {
            query = query.Where(x => x.Completed == filters.Completed);
        }
        if (filters.CategoryId != null)
        {
            query = query.Where(x => x.CategoryId == filters.CategoryId);
        }
        if (filters.StartDate != null)
        {
            query = query.Where(x => x.EndDate >= filters.StartDate);
        }
        if (filters.EndDate != null)
        {
            query = query.Where(x => x.EndDate <= filters.EndDate);
        }
        if (filters.Priority != null)
        {
            query = query.Where(x => x.Priority == filters.Priority);
        }
        if(filters.Title == null && filters.Completed == null && filters.CategoryId == null && filters.StartDate == null && filters.EndDate == null && filters.Priority == null)
        {
            throw new NotFoundException(Messages.ToDoNotFoundMessage);
        }
        return query;
    }
}
