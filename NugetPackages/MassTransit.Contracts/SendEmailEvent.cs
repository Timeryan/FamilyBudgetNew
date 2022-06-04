namespace MassTransit.Contracts;

public interface SendEmailEvent
{
    public string Email { get; set; }
    public string Subject { get; set; }
    public string Message { get; set; }
}