using Microsoft.AspNetCore.Identity;

namespace ToDoList.Models.Entities;

public sealed class User : IdentityUser
{
    public DateTime BirthDate { get; set; }
    public List<ToDo>? ToDos { get; set; }
    public List<Category>? Categories { get; set; }

}