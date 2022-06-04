using MailKit.Net.Smtp;
using MassTransit;
using MassTransit.Contracts;
using MimeKit;

namespace EmailService;

class SendEmailConsumer : IConsumer<SendEmailEvent>
{
    public async Task Consume(ConsumeContext<SendEmailEvent> context)
    {
        var request = context.Message;

        try
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("FamilyBudget", "budget.family@inbox.ru"));
            emailMessage.To.Add(new MailboxAddress("", request.Email));
            emailMessage.Subject = request.Subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = request.Message
            };

            using var client = new SmtpClient();
            await client.ConnectAsync("smtp.mail.ru", 465, true);
            await client.AuthenticateAsync("budget.family@inbox.ru", "H4kiaAv6RAV547Prs2dX");
            await client.SendAsync(emailMessage);

            await client.DisconnectAsync(true);
        }
        catch (Exception e)
        {
            throw new Exception($"Ошибка отправки сообщения на Email {e.Message}");
        }
    }
}