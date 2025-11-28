using Medicines.Data.Models.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Medicines.Common.EntityValidation.Patient;

namespace Medicines.DataProcessor.ImportDtos
{
    public class ImportPatientDto
    {
        [JsonProperty("FullName")]
        [Required]
        [MaxLength(FullNameMaxLength)]
        [MinLength(FullNameMinLength)]
        public string FullName { get; set; } = null!;

        [JsonProperty("AgeGroup")]
        [Required]
        public string AgeGroup { get; set; } = null!;

        [JsonProperty("Gender")]
        [Required]
        public string Gender { get; set; } = null!;

        [JsonProperty("Medicines")]
        public int[] Medicines { get; set; } = null!;
    }
}
