using DNSParser.CoreDataEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNSParser.Repository
{
    public interface IRepository<T> where T : BaseItem
    {
        IEnumerable<T> GetAll();
        T Get(long id);
        T Get(string id);
        bool Insert(T entity);
        bool Update(T entity);
        bool Delete(T entity);
        bool Remove(T entity);
        void SaveChanges();
    }
}
