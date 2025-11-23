

namespace ProductShop.DTOs.Export
{
    using System.Xml.Serialization;

    [XmlType("Users")]
    public class ExportUsersWithProductsDto
    {
        [XmlElement("count")]
        public int UsersCount { get; set; }

        [XmlArray("users")]
        public UserWithProductsDto[] Users { get; set; } = null!;
    }
}
