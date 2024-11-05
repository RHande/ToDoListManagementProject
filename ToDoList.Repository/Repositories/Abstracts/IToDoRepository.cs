using Core.Repository;
using ToDoList.Models.Entities;

namespace ToDoList.Repository.Repositories.Abstracts;

public interface IToDoRepository : IRepository<ToDo, Guid>
{
    
}