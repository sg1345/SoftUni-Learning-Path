

namespace ProductShop.DTOs.Import
{
    using System.ComponentModel.DataAnnotations;
    using Newtonsoft.Json;
    public class ImportCategoriesDto
    {
        [Required]
        [JsonProperty("name")]
        public string Name { get; set; } = null!;
    }
}
