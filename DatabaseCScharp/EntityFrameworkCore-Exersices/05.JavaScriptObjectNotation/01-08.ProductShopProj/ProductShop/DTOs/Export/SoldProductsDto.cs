
namespace ProductShop.DTOs.Export
{
    using System.ComponentModel.DataAnnotations;
    using Newtonsoft.Json;

    public class SoldProductsDto
    {
        [Required]
        [JsonProperty("name")]
        public string Name { get; set; } = null!;

        [Required]
        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("buyerFirstName")]
        public string? BuyerFirstName { get; set; }

        [Required]
        [JsonProperty("buyerLastName")]
        public string BuyerLastName { get; set; } = null!;
    }
}
