using ToDoList.Models.Enums;

namespace ToDoList.Models.Dtos.ToDos.Request;

public record ToDoFilterRequestDto(
    string? Title,  
    bool? Completed, 
    int? CategoryId,
    DateTime? StartDate,
    DateTime? EndDate,
    Priority? Priority);