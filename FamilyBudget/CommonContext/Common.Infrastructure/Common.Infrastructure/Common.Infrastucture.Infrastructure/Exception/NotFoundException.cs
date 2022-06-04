namespace Common.Infrastucture.Infrastructure.Exception;

public class NotFoundException : UserReadableException
{
    public NotFoundException(string message) : base(message)
    {
    } 
}