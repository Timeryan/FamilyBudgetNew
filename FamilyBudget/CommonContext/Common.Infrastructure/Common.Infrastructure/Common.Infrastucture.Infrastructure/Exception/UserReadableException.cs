namespace Common.Infrastucture.Infrastructure.Exception;

public class UserReadableException : System.Exception
{
    public UserReadableException(string message) : base(message)
    {
    } 
}