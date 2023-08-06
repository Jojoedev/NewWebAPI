using WebAPI.Models;

namespace WebAPI.Repositories
{
    public class InMemoryItemsRepository : IItemsInterface
    {
        private readonly List<Item> items = new List<Item>()
        {

            new Item{Id = Guid.NewGuid(), Name = "Mercedes", Price= 9, DateCreated = DateTimeOffset.UtcNow },
            new Item{Id = Guid.NewGuid(), Name = "Corrola", Price=19, DateCreated = DateTimeOffset.UtcNow },
            new Item{Id = Guid.NewGuid(), Name = "Lexus", Price=15, DateCreated = DateTimeOffset.UtcNow },
            new Item{Id = Guid.NewGuid(), Name = "Nissan", Price=24, DateCreated = DateTimeOffset.UtcNow },
            new Item(){Name = "Mazda", Id = Guid.NewGuid(), Price= 30, DateCreated = DateTimeOffset.UtcNow}
        };

        public IEnumerable<Item> GetItems()
        {
            return items;
        }

        public Item GetItem(Guid id)
        {
            //Retrieve the Item form the Item in Memory Db using its object "items".
            var item = items.FirstOrDefault(x => x.Id == id);
            //var item = items.Where(n => n.Id == id).SingleOrDefault();
            
            //return the output of the retrieved item for the DB since the return type is an item of the Item list.
            return item;
        }

        public void CreateItem(Item item)
        {
            {
              items.Add(item);    
            }
            
        }

        public void EditItem(Item item)
        {
            var ItemIndex = items.FindIndex(existingItem => existingItem.Id == item.Id);
            items[ItemIndex] = item;

            //Assuming a Database is used to store data.
            //var SearchItem = items.Find(x => x.Id == Id);
            
            
        }

        public void DeleteItem(Guid id)
        {
            var FindIndex = items.FindIndex(x => x.Id == id);
            items.RemoveAt(FindIndex);
        }
    }
}
