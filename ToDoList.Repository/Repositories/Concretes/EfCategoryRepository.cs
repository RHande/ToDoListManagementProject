using Core.Repository;
using ToDoList.Models.Entities;
using ToDoList.Repository.Contexts;
using ToDoList.Repository.Repositories.Abstracts;

namespace ToDoList.Repository.Repositories.Concretes;

public class EfCategoryRepository : EfRepositoryBase<BaseDbContext, Category, int>, ICategoryRepository
{
    public EfCategoryRepository(BaseDbContext context) : base(context)
    {
    }
    
}