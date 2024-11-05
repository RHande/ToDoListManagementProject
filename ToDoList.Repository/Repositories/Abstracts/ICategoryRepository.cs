using Core.Repository;
using ToDoList.Models.Entities;

namespace ToDoList.Repository.Repositories.Abstracts;

public interface ICategoryRepository : IRepository<Category, int>
{
    
}