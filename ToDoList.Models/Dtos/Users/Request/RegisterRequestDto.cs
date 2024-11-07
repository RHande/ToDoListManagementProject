namespace ToDoList.Models.Dtos.Users.Request;

public record RegisterRequestDto(
    string Username, 
    string FirstName, 
    string LastName, 
    string Email, 
    string Password, 
    DateTime BirthDate);