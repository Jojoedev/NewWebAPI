using WebAPI.Models;

namespace WebAPI.DataTO
{
    public record ItemDTO
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public decimal Price { get; init; }
        public DateTimeOffset DateCreated { get; init; }


       
    }

    //Extenstion Method. This is an utility method.
    /*public static class Extention
    {
        public static ItemDTO AsDTO(this Item item)
        {
            return new ItemDTO
            {
                Name = item.Name,
                Price = item.Price,
                DateCreated = item.DateCreated,
                Id = Guid.NewGuid()
            };
        }
    }*/
}
