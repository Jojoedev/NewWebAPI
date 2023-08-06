using WebAPI.DataTO;
using WebAPI.Models;

namespace WebAPI
{
    public static class Extensions
    {
        public static ItemDTO AsDTO(this Item item)
        {
            //Copying Item properties to ItemDTO.
            return new ItemDTO
            {
                Id = item.Id,
                Name = item.Name,
                Price = item.Price,
                DateCreated = item.DateCreated
            };

        }
    }
}
