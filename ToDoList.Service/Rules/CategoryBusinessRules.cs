using Core.Exceptions;
using ToDoList.Repository.Repositories.Abstracts;
using ToDoList.Service.Constants;


namespace ToDoList.Service.Rules;

public class CategoryBusinessRules (ICategoryRepository _categoryRepository)
{
    public void CategoryIsPresent(int id)
    {
        var category = _categoryRepository.GetById(id);
        if (category == null)
        {
            throw new NotFoundException(Messages.CategoryIsNotPresentMessage(id));
        }
    }
    
    public void CategoryListIsEmpty()
    {
        var categories = _categoryRepository.GetAll();
        if (categories.Count == 0)
        {
            throw new NotFoundException("There is no category in the system.");
        }
    }
}