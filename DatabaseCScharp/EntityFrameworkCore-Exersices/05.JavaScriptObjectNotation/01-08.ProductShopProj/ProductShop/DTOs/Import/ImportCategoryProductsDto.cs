

namespace ProductShop.DTOs.Import
{
    using System.ComponentModel.DataAnnotations;
    using Newtonsoft.Json;
    public class ImportCategoryProductsDto
    {
        [Required]
        [JsonProperty("CategoryId")]
        public string CategoryId { get; set; } = null!;

        [Required]
        [JsonProperty("ProductId")]
        public string ProductId { get; set; } = null!;
    }
}
