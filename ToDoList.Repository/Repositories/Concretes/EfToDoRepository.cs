using Core.Repository;
using ToDoList.Models.Entities;
using ToDoList.Repository.Contexts;
using ToDoList.Repository.Repositories.Abstracts;

namespace ToDoList.Repository.Repositories.Concretes;

public class EfToDoRepository : EfRepositoryBase<BaseDbContext, ToDo, Guid>, IToDoRepository
{
    public EfToDoRepository(BaseDbContext context) : base(context)
    {
    }
    
}
