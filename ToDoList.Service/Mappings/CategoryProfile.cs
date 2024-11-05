using AutoMapper;
using ToDoList.Models.Dtos.Categories.Request;
using ToDoList.Models.Dtos.Categories.Response;
using ToDoList.Models.Entities;

namespace ToDoList.Service.Mappings;

public class CategoryProfile : Profile
{
    public CategoryProfile()
    {
        CreateMap<AddCategoryRequestDto, Category>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());
        CreateMap<Category, CategoryWithToDoResponseDto>();
        CreateMap<Category, CategoryResponseDto>();
        CreateMap<UpdateCategoryRequestDto, Category>().ReverseMap();
    }
}