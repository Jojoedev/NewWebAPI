using System.ComponentModel.DataAnnotations;

namespace WebAPI.DataTO
{
    public record CreateItemDTO
    {
        [Required]
        public string Name { get; init; }
        [Required]
        [Range(6,100)]
        public decimal Price { get; init; }
    }
}
