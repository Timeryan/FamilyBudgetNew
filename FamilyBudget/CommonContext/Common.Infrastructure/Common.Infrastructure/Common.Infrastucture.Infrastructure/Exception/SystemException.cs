namespace Common.Infrastucture.Infrastructure.Exception;

public class SystemException : System.Exception
{
    public SystemException(string message) : base(message)
    {
        
    }
}