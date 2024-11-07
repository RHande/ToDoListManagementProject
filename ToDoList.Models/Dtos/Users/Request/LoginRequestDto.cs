namespace ToDoList.Models.Dtos.Users.Request;

public record LoginRequestDto(
    string Email, 
    string Password);