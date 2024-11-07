namespace Core.Exceptions;

public class BusinessException(string message) : Exception (message);
public class ForbiddenException(string message) : Exception (message);