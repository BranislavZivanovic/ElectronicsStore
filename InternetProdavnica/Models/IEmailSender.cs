namespace InternetProdavnica.Models
{
    public interface IEmailSender
    {
        void SendEmail(Message message);
    }
}
