


namespace ProductShop.DTOs.Export
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Product")]
    public class SoldProductDetailsDto
    {
        [Required]
        [XmlElement("name")]
        public string Name { get; set; } = null!;

        [Required]
        [XmlElement("price")]
        public decimal Price { get; set; }
    }
}
