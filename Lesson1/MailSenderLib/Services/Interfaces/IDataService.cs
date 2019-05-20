using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSenderLib.Services.Interfaces
{
    public interface IDataService<T>
    {
        IEnumerable<T> GetAll();

        T GetById(int id);

        int Add(T recipient);

        void Edit(T recipient);

        void Remove(int id);

        void SaveChanges();
    }
}
