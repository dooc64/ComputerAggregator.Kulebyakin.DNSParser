using DNSParser.CoreDataEntities;
using DNSParser.Repository;

namespace DNSParser.CoreService
{
    public class ItemService : IItemService
    {
        private IRepository<BaseItem> _itemRepository;

        public ItemService(IRepository<BaseItem> itemRepository)
        {
            _itemRepository = itemRepository;
        }

        private BaseItem GetItemFromDns(string name)
        {
            var parser = new ParserService();

            var result = parser.SearchItem(name, 1);

            return result;
        }

        public bool DeleteItem(long id)
        {
            var itemRepository = GetItem(id);

            var result = _itemRepository.Remove(itemRepository);
            _itemRepository.SaveChanges();
            return result;
        }

        public BaseItem GetItem(long id)
        {
            return _itemRepository.Get(id);
        }

        public BaseItem GetItem(string name)
        {
            var result = _itemRepository.Get(name);
            if (result == null)
            {
                result = GetItemFromDns(name);
                _itemRepository.Insert(result);
            }
            return result;
        }

        public IEnumerable<BaseItem> GetItems()
        {
            return _itemRepository.GetAll();
        }

        public bool InsertItem(BaseItem item)
        {
            return _itemRepository.Insert(item);
        }

        public bool UpdateItem(BaseItem item)
        {
            return _itemRepository.Update(item);
        }
    }
}