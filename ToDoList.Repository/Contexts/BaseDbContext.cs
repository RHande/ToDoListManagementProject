using System.Reflection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ToDoList.Models.Entities;

namespace ToDoList.Repository.Contexts;

public class BaseDbContext : IdentityDbContext<User, IdentityRole, string>
{
public BaseDbContext(DbContextOptions options) : base(options)
{
}

protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    base.OnModelCreating(modelBuilder);
    modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
}
    
    public DbSet<Category> Categories { get; set; }
    public DbSet<ToDo> ToDos { get; set; }
    
}
