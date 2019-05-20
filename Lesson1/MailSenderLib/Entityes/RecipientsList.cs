using MailSenderLib.Entityes.Base;
using MailSenderLib.Linq2SQL;
using System.Collections.Generic;

namespace MailSenderLib.Entityes
{
    public class RecipientsList : BaseEntity
    {
        public string Name { get; set; }

        public IEnumerable<Recepients> Recipients { get; set; }
    }
}
