using MailSenderLib.Entityes.Base;
using MailSenderLib.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSenderLib.Services.InMemory
{
    public abstract class DataInMemory<T> : IDataService<T> where T : BaseEntity
    {
        private readonly List<T> _Items = new List<T>();
        public int Add(T item)
        {
            if (_Items.Contains(item)) return 0;
            item.Id = _Items.Count == 0 ? 1 : _Items.Max(i => i.Id) + 1;
            _Items.Add(item);
            return item.Id;
        }

        public abstract void Edit(T recipient);        

        public IEnumerable<T> GetAll() => _Items;
        

        public T GetById(int id)
        {
            return _Items.FirstOrDefault(item => item.Id == id);
        }
        

        public void Remove(int id)
        {
            var item = GetById(id);
            if (item is null) return;
            _Items.Remove(item);
        }

        public void SaveChanges() { }       
    }
}
