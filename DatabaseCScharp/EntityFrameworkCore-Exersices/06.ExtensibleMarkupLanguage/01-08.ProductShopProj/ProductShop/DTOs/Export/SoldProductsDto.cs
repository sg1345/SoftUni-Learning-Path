namespace ProductShop.DTOs.Export
{
    using System.Xml.Serialization;
    public class SoldProductsDto
    {
        [XmlElement("count")]
        public int Count { get; set; }

        [XmlArray("products")]
        public SoldProductDetailsDto[] Products { get; set; } = null!;
    }
}
