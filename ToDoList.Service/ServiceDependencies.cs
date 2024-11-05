using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using ToDoList.Service.Rules;
using ToDoList.Service.Services.Abstracts;
using ToDoList.Service.Services.Concretes;

namespace ToDoList.Service;

public static class ServiceDependencies
{
    public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
    {
        services.AddScoped<ICategoryService, CategoryService>();


        services.AddScoped<CategoryBusinessRules>();
        services.AddScoped<ToDoBusinessRules>();
        
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        return services;
    }
}