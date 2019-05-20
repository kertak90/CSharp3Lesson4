using MailSenderLib.Entityes.Base;

namespace MailSenderLib.Entityes
{
    public class MailMessage : BaseEntity
    {
        public string Subject { get; set; }

        public string Body { get; set; }
    }
}
