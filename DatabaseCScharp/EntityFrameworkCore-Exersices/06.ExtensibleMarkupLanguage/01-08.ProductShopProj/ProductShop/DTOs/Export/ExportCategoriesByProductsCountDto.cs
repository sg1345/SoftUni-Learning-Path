


namespace ProductShop.DTOs.Export
{
    using System.Xml.Serialization;

    [XmlType("Category")]
    public class ExportCategoriesByProductsCountDto
    {
        [XmlElement("name")]
        public string CategoryName { get; set; } = null!;

        [XmlElement("count")]
        public int ProductsCount { get; set; }

        [XmlElement("averagePrice")]
        public string AveragePrice { get; set; } = null!;

        [XmlElement("totalRevenue")]
        public string TotalRevenue { get; set; } = null!;
    }
}
