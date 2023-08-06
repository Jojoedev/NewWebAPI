using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebAPI.DataTO;
using WebAPI.Models;
using WebAPI.Repositories;

namespace WebAPI.Controllers
{
    //Get /items

    [ApiController]
    [Route("items")]
    public class ItemsController : Controller
    {
        private readonly IItemsInterface _repository;

        public ItemsController(IItemsInterface repository)
        {
            _repository = repository;
        }

        /* public ItemsController()
         {
             _repository = new InMemoryItemsRepository();
         }*/

        //Get /items
        [HttpGet]

       public IEnumerable<ItemDTO> GetAllItems()
        {

           var items = _repository.GetItems().Select(x => x.AsDTO());
            
            
            /*var it = _repository.GetItems().Select(item => new ItemDTO
            {
                Id = Guid.NewGuid(),
                Name = item.Name,
                Price = item.Price

            });*/

           // item => new ItemDTO; This is an anonymous function that takes parameter item and return new ItemDTO
            //Item item = new ItemDTO. This is a mere assignment of an instance of Item class "item" to new ItemDto

            return items;
        }


        
        //GET /items/{id}
        [HttpGet("{id}")]
        
        public ActionResult<ItemDTO> GetOneItem(Guid id)
        {
            var item = _repository.GetItem(id);
            if(item is null)
            {
                return NotFound();
            }
            return item.AsDTO();

                 /*new ItemDTO
                 {
                     Id = Guid.NewGuid(),
                     Name = item.Name,
                     Price = item.Price,
                     DateCreated = item.DateCreated
                 };
            */
                
    }

     

        [HttpPost]
        public ActionResult<ItemDTO> Create(CreateItemDTO createItemDTO)
        {
            //Assigning Item properties from "obj of CreateItemDTO";
            Item item = new Item()
            {
                Id = Guid.NewGuid(),
                Name = createItemDTO.Name,
                Price = createItemDTO.Price,
                DateCreated = DateTime.Now,
            };

            _repository.CreateItem(item);
            return CreatedAtAction(nameof(GetOneItem), new {id = item.Id }, item.AsDTO()) ;
            
        }

        


        // PUT /items/{id}

        [HttpPut("{id}")]
        public ActionResult Update(Guid id, UpdateItemDTO updateItemDTO)
        {
            var itemToUpdate = _repository.GetItem(id);
            if(itemToUpdate == null)
            {
                return NotFound();
            }

            //Here, you are copying the itemToUpdate into the original item/prototype.
            Item NewItem = itemToUpdate with
            {
                Name = updateItemDTO.Name,
                Price = updateItemDTO.Price,
            };

            _repository.EditItem(NewItem);
            return NoContent();

        }

        //DELETE /items/{id}

        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var DelItem = _repository.GetItem(id);
            if (DelItem == null)
            {
                return NotFound();
            }

            _repository.DeleteItem(id);
            return NoContent();
        }
    }
}
