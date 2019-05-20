using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSenderLib.Entityes.Base
{
    public class Human : BaseEntity
    {
        public string Name { get; set; }

        public string Email { get; set; }
    }
}
