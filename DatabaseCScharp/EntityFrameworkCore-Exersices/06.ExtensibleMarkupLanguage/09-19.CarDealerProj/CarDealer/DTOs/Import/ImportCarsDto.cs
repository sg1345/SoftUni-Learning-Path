

namespace CarDealer.DTOs.Import
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Car")]
    public class ImportCarsDto
    {
        [Required]
        [XmlElement("make")]
        public string Make { get; set; } = null!;

        [Required]
        [XmlElement("model")]
        public string Model { get; set; } = null!;

        [Required]
        [XmlElement("traveledDistance")]
        public string TraveledDistance { get; set; } = null!;

        [Required]
        [XmlArray("parts")]
        public PartDto[] Parts { get; set; } = null!;
    }
}
