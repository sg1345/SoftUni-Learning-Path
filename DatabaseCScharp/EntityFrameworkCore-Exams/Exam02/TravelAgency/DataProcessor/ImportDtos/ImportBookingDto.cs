using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TravelAgency.Common.EntityValidation;


namespace TravelAgency.DataProcessor.ImportDtos
{
    public class ImportBookingDto
    {
        [JsonProperty("BookingDate")]
        [Required]
        public string BookingDate { get; set; } = null!;

        [JsonProperty("CustomerName")]
        [Required]
        [MaxLength(Customer.FullNameMaxLength)]
        [MinLength(Customer.FullNameMinLength)]
        public string CustomerName { get; set; } = null!;

        [JsonProperty("TourPackageName")]
        [Required]
        [MaxLength(TourPackage.PackageNameMaxLength)]
        [MinLength(TourPackage.PackageNameMinLength)]
        public string TourPackageName { get; set; } = null!;

    }
}
