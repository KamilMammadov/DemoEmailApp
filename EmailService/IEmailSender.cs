namespace DemoEmailApp.EmailService
{
    public interface IEmailSender
    {
        void SendEmail(Message message);
    }
}
