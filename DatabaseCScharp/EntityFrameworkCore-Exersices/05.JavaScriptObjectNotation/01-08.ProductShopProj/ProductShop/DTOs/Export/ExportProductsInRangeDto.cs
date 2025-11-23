using Newtonsoft.Json;

namespace ProductShop.DTOs.Export
{
    using System.ComponentModel.DataAnnotations;
    public class ExportProductsInRangeDto
    {
        [Required]
        [JsonProperty("name")]
        public string Name { get; set; } = null!;

        [Required]
        [JsonProperty("price")]
        public decimal Price { get; set; }

        [Required]
        [JsonProperty("seller")]
        public string Seller { get; set; } = null!;
    }
}
