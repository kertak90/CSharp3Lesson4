using MailSenderLib.Entityes.Base;
using System.Collections.Generic;

namespace MailSenderLib.Entityes
{
    public class MailList : BaseEntity
    {
        public string Name { get; set; }

        public IEnumerable<MailMessage> Messages { get; set; }
    }
}
