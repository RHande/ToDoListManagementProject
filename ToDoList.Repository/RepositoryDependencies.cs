using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ToDoList.Repository.Contexts;
using ToDoList.Repository.Repositories.Abstracts;
using ToDoList.Repository.Repositories.Concretes;
using Microsoft.Extensions.Configuration;

namespace ToDoList.Repository;

public static class RepositoryDependencies
{
    public static IServiceCollection AddRepositoryDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ICategoryRepository, EfCategoryRepository>();
        services.AddScoped<IToDoRepository, EfToDoRepository>();
        
        services.AddDbContext<BaseDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("SqlConnection")));
        return services;
    }
}