


namespace ProductShop.DTOs.Export
{
    using System.ComponentModel.DataAnnotations;
    using Newtonsoft.Json;
    public class ExportSoldProductsDto
    {
        
        [JsonProperty("firstName")]
        public string? FirstName { get; set; }

        [Required]
        [JsonProperty("lastName")]
        public string LastName { get; set; } = null!;

        [JsonProperty("soldProducts")]
        public List<SoldProductsDto> SoldProducts { get; set; } = new List<SoldProductsDto>();
    }
}
