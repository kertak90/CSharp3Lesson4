using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailSenderLib;
using MailSenderLib.Entityes;

namespace MailSenderLib
{
    public static class TestData
    {
        public static List<Sender> Senders { get; } = new List<Sender>
        {
            new Sender{Name = "Иванов", Email = "ivanov@yandex.ru"},
            new Sender{Name = "Петров", Email = "petrov@yandex.ru"},
            new Sender{Name = "Сидоров", Email = "sidorov@yandex.ru"}
        };

        public static List<Server> Servers { get; } = new List<Server>
        {
            new Server{ Name = "Яндекс", Address = "smtp.yandex.ru", Port=25, UseSSL = true, Login = "UserName", Password = "password" },
            new Server{ Name = "Mail.ru", Address = "smtp.mail.ru", Port=25, UseSSL = true, Login = "UserName", Password = "password" },
            new Server{ Name = "Gmail.com", Address = "smtp.gmail.ru", Port=25, UseSSL = true, Login = "UserName", Password = "password" }
        };
                

        
    }
}
