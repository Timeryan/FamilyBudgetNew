using Common.Contracts.Publisher.Contracts.EmailSend;

namespace Common.Application.AppServices.Publishers;

public interface IEmailPublisher
{
    public Task PublishSendEmailAsync(SendEmailRequest request);
}