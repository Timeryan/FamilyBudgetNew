using Common.Contracts.Publisher.Contracts.EmailSend;
using MassTransit;
using MassTransit.Contracts;


namespace Common.Application.AppServices.Publishers
{
    public class EmailPublisher : IEmailPublisher
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public EmailPublisher(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        public async Task PublishSendEmailAsync(SendEmailRequest request)
        {
            await _publishEndpoint.Publish<SendEmailEvent>(new
            {
                request.Email,
                request.Subject,
                request.Message
            });
            /*try
            {
                var emailMessage = new MimeMessage();
 
                emailMessage.From.Add(new MailboxAddress("FamilyBudget", "budget.family@inbox.ru"));
                emailMessage.To.Add(new MailboxAddress("", email));
                emailMessage.Subject = subject;
                emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
                {
                    Text = message
                };

                using var client = new SmtpClient();
                await client.ConnectAsync("smtp.mail.ru", 465, true);
                await client.AuthenticateAsync("budget.family@inbox.ru", "H4kiaAv6RAV547Prs2dX");
                await client.SendAsync(emailMessage);

                await client.DisconnectAsync(true);
            }
            catch (Exception e)
            {
                throw new SendEmailException($"Ошибка отправки сообщения на Email {e.Message}");
            }*/
            
        }
    }
}