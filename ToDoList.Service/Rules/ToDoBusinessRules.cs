using Core.Exceptions;
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
}