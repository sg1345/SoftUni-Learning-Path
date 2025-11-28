using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Cadastre.Common.EntityValidation.Citizen;

namespace Cadastre.DataProcessor.ImportDtos
{
    public class ImportCitizenDto
    {
        [JsonProperty("FirstName")]
        [Required]
        [MaxLength(FirstNameMaxLength)]
        [MinLength(FirstNameMinLength)]
        public string FirstName { get; set; } = null!;

        [JsonProperty("LastName")]
        [Required]
        [MaxLength(LastNameMaxLength)]
        [MinLength(LastNameMinLength)]
        public string LastName { get; set; } = null!;
        [JsonProperty("BirthDate")]
        [Required]

        public string BirthDate { get; set; } = null!;

        [JsonProperty("MaritalStatus")]
        [Required]
        public string MaritalStatus { get; set; } = null!;

        [JsonProperty("Properties")]
        public int[] Properties { get; set; } = null!;
    }
}
