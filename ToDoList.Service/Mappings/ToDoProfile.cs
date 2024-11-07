using AutoMapper;
using ToDoList.Models.Dtos.ToDos.Request;
using ToDoList.Models.Dtos.ToDos.Response;
using ToDoList.Models.Entities;

namespace ToDoList.Service.Mappings;

public class ToDoProfile : Profile
{
    public ToDoProfile()
    {
        CreateMap<AddToDoRequestDto, ToDo>();
        CreateMap<ToDo, ToDoResponseDto>()
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
            .ForMember(dest=>dest.UserName,opt=>opt.MapFrom(src=>src.User.UserName)).ReverseMap();
        CreateMap<UpdateToDoRequestDto, ToDo>().ReverseMap();
        CreateMap<ToDoFilterRequestDto, ToDo>().ReverseMap();
    }
}