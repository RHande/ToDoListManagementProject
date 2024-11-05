using ToDoList.Models.Entities;

namespace ToDoList.Models.Dtos.Categories.Response;

public sealed record CategoryWithToDoResponseDto
{
    public int Id { get; init; }
    public string Name { get; init; }
    public List<ToDo> ToDos { get; init; }
}