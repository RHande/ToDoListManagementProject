namespace ToDoList.Models.Dtos.Users.Request;

public record ChangePasswordRequestDto(
    string OldPassword,
    string NewPassword);