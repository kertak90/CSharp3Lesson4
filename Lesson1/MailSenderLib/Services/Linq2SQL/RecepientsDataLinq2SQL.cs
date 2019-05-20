using MailSenderLib.Linq2SQL;
using MailSenderLib.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSenderLib.Services
{
    public class RecepientsDataLinq2SQL : IRecepientsData
    {
        private readonly MailSenderDB _db;
        public RecepientsDataLinq2SQL(MailSenderDB db)
        {
            _db = db;
        }

        public int Add(Recepients recipient)
        {
            throw new NotImplementedException();
        }

        public int Create(Recepients recepients)
        {
            if (recepients.Id != 0) return recepients.Id;
            _db.Recepients.InsertOnSubmit(recepients);
            return recepients.Id;
        }

        public void Edit(Recepients recipient)
        {
            if (_db.Recepients.Contains(recipient)) return;
            _db.Recepients.InsertOnSubmit(recipient);
        }

        public IEnumerable<Recepients> GetAll()
        {
            return _db.Recepients.ToArray();
        }

        public Recepients GetById(int id)
        {
            return _db.Recepients.FirstOrDefault(i => i.Id ==id);
        }

        public void Remove(int id)
        {
            var item = GetById(id);
            _db.Recepients.DeleteOnSubmit(item);
            SaveChanges();
        }

        public void SaveChanges()
        {
            _db.SubmitChanges();
        }

        public void Write(Recepients recipient)
        {
            if (_db.Recepients.Contains(recipient)) return;
            _db.Recepients.InsertOnSubmit(recipient);
        }
    }
}
