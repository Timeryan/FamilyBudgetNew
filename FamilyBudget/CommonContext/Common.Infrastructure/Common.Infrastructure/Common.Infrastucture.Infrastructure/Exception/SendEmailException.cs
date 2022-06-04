namespace Common.Infrastucture.Infrastructure.Exception;

public class SendEmailException : SystemException
{
    public SendEmailException(string message) : base(message)
    {
        
    }
}