namespace WebAPI.DataTO
{
    public record UpdateItemDTO
    {
        public string Name { get; init; }
        public decimal Price { get; init; }
    }
}
