using DNSParser.CoreDataEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNSParser.CoreService
{
    public interface IItemService
    {
        IEnumerable<BaseItem> GetItems();
        BaseItem GetItem(long id);
        BaseItem GetItem(string name);
        bool InsertItem(BaseItem user);
        bool UpdateItem(BaseItem user);
        bool DeleteItem(long id);
    }
}
