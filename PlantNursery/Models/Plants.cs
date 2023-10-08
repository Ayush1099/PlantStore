using System.ComponentModel.DataAnnotations;

namespace PlantNursery.Models
{
    public class Plants
    {
        [Key]
        public string PlantId { get; set; } 
        public string? PlantName { get; set; }
        public decimal Price { get; set; }
        public int QuantityAvailable { get; set; }
    }
}
