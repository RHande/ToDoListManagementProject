using AutoMapper;
using Core.Entities;
using ToDoList.Models.Dtos.Categories.Request;
using ToDoList.Models.Dtos.Categories.Response;
using ToDoList.Models.Entities;
using ToDoList.Repository.Repositories.Abstracts;
using ToDoList.Service.Constants;
using ToDoList.Service.Rules;
using ToDoList.Service.Services.Abstracts;

namespace ToDoList.Service.Services.Concretes;

public class CategoryService (ICategoryRepository categoryRepository, IMapper mapper, CategoryBusinessRules categoryBusinessRules) : ICategoryService
{
    public ReturnModel<CategoryResponseDto> Add(AddCategoryRequestDto dto)
    {
        Category createdCategory = mapper.Map<Category>(dto);
        Category category = categoryRepository.Add(createdCategory);
        CategoryResponseDto response = mapper.Map<CategoryResponseDto>(category);
        return new ReturnModel<CategoryResponseDto>()
        {
            Data = response,
            Message = Messages.CategoryAddedMessage,
            Status = 200,
            Success = true
        };
    }

    public ReturnModel<List<CategoryResponseDto>> GetAll()
    {
        categoryBusinessRules.CategoryListIsEmpty();
        List<Category> categories = categoryRepository.GetAll();
        List<CategoryResponseDto> response = mapper.Map<List<CategoryResponseDto>>(categories);
        return new ReturnModel<List<CategoryResponseDto>>()
        {
            Data = response,
            Message = Messages.CategoryFetchedMessage,
            Status = 200,
            Success = true
        };
    }

    public ReturnModel<CategoryResponseDto> GetById(int id)
    {
        categoryBusinessRules.CategoryIsPresent(id);
        Category? category = categoryRepository.GetById(id);
        CategoryResponseDto response = mapper.Map<CategoryResponseDto>(category);
        return new ReturnModel<CategoryResponseDto>()
        {
            Data = response,
            Message = Messages.CategoryFetchedMessage,
            Status = 200,
            Success = true
        };
    }

    public ReturnModel<CategoryResponseDto> Update(UpdateCategoryRequestDto dto)
    {
        categoryBusinessRules.CategoryIsPresent(dto.Id);
        Category? category = categoryRepository.GetById(dto.Id);
        if (category != null) category.Name = dto.Name;
        categoryRepository.Update(category);
        CategoryResponseDto response = mapper.Map<CategoryResponseDto>(category);
        return new ReturnModel<CategoryResponseDto>()
        {
            Data = response,
            Message = Messages.CategoryUpdatedMessage,
            Status = 200,
            Success = true
        };
    }

    public ReturnModel<string> Delete(int id)
    {
        Category? category = categoryRepository.GetById(id);
        if (category != null) categoryRepository.Delete(category);
        return new ReturnModel<string>()
        {
            Data = $"Deleted category name: {category?.Name}",
            Message = Messages.CategoryDeletedMessage,
            Status = 200,
            Success = true
        };
    }

    public ReturnModel<List<CategoryResponseDto>> GetByName(string name)
    {
        List<Category> categories = categoryRepository.GetAll(x=>x.Name == name);
        List<CategoryResponseDto> response = mapper.Map<List<CategoryResponseDto>>(categories);
        return new ReturnModel<List<CategoryResponseDto>>()
        {
            Data = response,
            Message = Messages.CategoryFetchedMessage,
            Status = 200,
            Success = true
        };
    }

    public ReturnModel<List<CategoryResponseDto>> GetAllByNameContains(string text)
    {
        List<Category> categories = categoryRepository.GetAll(x => x.Name.Contains(text));
        List<CategoryResponseDto> response = mapper.Map<List<CategoryResponseDto>>(categories);
        return new ReturnModel<List<CategoryResponseDto>>()
        {
            Data = response,
            Message = Messages.CategoryFetchedMessage,
            Status = 200,
            Success = true
        };
    }

    public ReturnModel<List<CategoryWithToDoResponseDto>> GetAllToDoByCategoryName(string name)
    {
        List<Category> categories = categoryRepository.GetAll(x => x.Name == name);
        List<CategoryWithToDoResponseDto> response = mapper.Map<List<CategoryWithToDoResponseDto>>(categories);
        return new ReturnModel<List<CategoryWithToDoResponseDto>>()
            {
            Data = response,
            Message = Messages.CategoryFetchedMessage,
            Status = 200,
            Success = true
        };
    }

    public ReturnModel<List<CategoryWithToDoResponseDto>> GetAllToDoByCategoryId(int id)
    {
        List<Category> categories = categoryRepository.GetAll(x => x.Id == id);
        List<CategoryWithToDoResponseDto> response = mapper.Map<List<CategoryWithToDoResponseDto>>(categories);
        return new ReturnModel<List<CategoryWithToDoResponseDto>>()
        {
            Data = response,
            Message = Messages.CategoryFetchedMessage,
            Status = 200,
            Success = true
        };
    }
}