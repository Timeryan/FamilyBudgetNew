namespace Common.Infrastucture.Infrastructure.Exception;

public class WrongDataException : UserReadableException
{
    public WrongDataException(string message) : base(message)
    {
    } 
}