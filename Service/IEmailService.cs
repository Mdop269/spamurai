namespace EmailSender.Service
{
    public interface IEmailService
    {
        Task SendEmail(string recepeint, string subject, string body);
    }
}
