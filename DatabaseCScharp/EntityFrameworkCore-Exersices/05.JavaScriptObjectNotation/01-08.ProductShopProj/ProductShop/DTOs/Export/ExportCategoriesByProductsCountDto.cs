using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ProductShop.Models;

namespace ProductShop.DTOs.Export
{
    public class ExportCategoriesByProductsCountDto
    {
        [Required]
        [JsonProperty("category")]
        public string Category { get; set; } = null!;

        [Required]
        [JsonProperty("productsCount")]
        public int ProductsCount { get; set; }

        [Required]
        [JsonProperty("averagePrice")]
        public string AveragePrice { get; set; } = null!;

        [Required]
        [JsonProperty("totalRevenue")]
        public string TotalRevenue { get; set; } = null!;
    }
}
