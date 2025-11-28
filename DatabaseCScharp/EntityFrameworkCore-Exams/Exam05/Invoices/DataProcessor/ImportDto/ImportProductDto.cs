using Invoices.Data.Models.Enums;
using Invoices.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Invoices.Common.EntityValidation.Product;
using Newtonsoft.Json;

namespace Invoices.DataProcessor.ImportDto
{
    public class ImportProductDto
    {
        [JsonProperty("Name")]
        [Required]
        [MaxLength(NameMaxLength)]
        [MinLength(NameMinLength)]
        public string Name { get; set; } = null!;

        [JsonProperty("Price")]
        [Required]
        [Range(typeof(decimal), PriceMin, PriceMax)]
        public decimal Price { get; set; }

        [JsonProperty("CategoryType")]
        [Required]
        public int CategoryType { get; set; }

        [JsonProperty("Clients")]
        public int[] Clients { get; set; }
    }
}
