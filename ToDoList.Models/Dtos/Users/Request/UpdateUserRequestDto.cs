namespace ToDoList.Models.Dtos.Users.Request;

public record UpdateUserRequestDto(
    string Username, 
    DateTime BirthDate
    );