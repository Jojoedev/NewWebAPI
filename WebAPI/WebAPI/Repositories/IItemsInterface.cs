using WebAPI.Models;

namespace WebAPI.Repositories
{
    public interface IItemsInterface
    {
        Item GetItem(Guid id);
        IEnumerable<Item> GetItems();
        void CreateItem(Item item);
        void EditItem(Item item);
        void DeleteItem(Guid id);

    }
}