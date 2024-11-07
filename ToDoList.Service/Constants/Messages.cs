namespace ToDoList.Service.Constants;

public static class Messages
{
    //Category Messages
    public const string CategoryAddedMessage = "Category added successfully";
    public const string CategoryUpdatedMessage = "Category updated successfully";
    public const string CategoryDeletedMessage = "Category deleted successfully";
    public const string CategoryFetchedMessage = "Category fetched successfully";
    public static string ToDoNotFoundMessage = "ToDo not found";

    public static string CategoryIsNotPresentMessage(int id) => $"Category with id {id} is not present";
    
    //ToDo Messages
    public const string ToDoAddedMessage = "ToDo added successfully";
    public const string ToDoUpdatedMessage = "ToDo updated successfully";
    public const string ToDoDeletedMessage = "ToDo deleted successfully";
    public const string ToDoFetchedMessage = "ToDo fetched successfully";
    public const string ToDoCompletedMessage = "ToDo completed successfully";
    public static string ToDoIsNotPresentMessage(Guid id) => $"ToDo with id {id} is not present";
    public const string ToDoTitleIsUniqueMessage = "ToDo title is must be unique";
    
    
    
    //User Messages
    public const string UserAddedMessage = "User added successfully";
    public const string UserUpdatedMessage = "User updated successfully";
    public const string UserDeletedMessage = "User deleted successfully";
    public const string UserFetchedMessage = "User fetched successfully";
    public static string UserIsNotPresentMessage(string id) => $"User with id {id} is not present";
    
}