using ToDoList.Models.Enums;

namespace ToDoList.Models.Dtos.ToDos.Request;

public record AddToDoRequestDto(
    string Title,
    string Description,
    DateTime StartDate,
    DateTime EndDate,
    bool Completed,
    Priority Priority,
    int CategoryId
    );