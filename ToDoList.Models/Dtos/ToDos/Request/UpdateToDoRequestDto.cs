using ToDoList.Models.Enums;

namespace ToDoList.Models.Dtos.ToDos.Request;

public sealed record UpdateToDoRequestDto(
    Guid Id,
    string? Title,
    string? Description,
    DateTime? EndDate,
    bool? Completed,
    Priority? Priority,
    int? CategoryId
    );