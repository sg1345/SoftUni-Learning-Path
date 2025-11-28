using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoices.Common
{
    public static class EntityValidation
    {
        public static class Product
        {
            public const int NameMinLength = 9;
            public const int NameMaxLength = 30;

            public const string PriceMin = "5.00";
            public const string PriceMax = "1000.00";
            public const string PriceTypeName = "decimal(6,2)";
        }

        public static class Address
        {
            public const int StreetNameMinLength = 10;
            public const int StreetNameMaxLength = 20;

            public const int CityMinLength = 5;
            public const int CityMaxLength = 15;

            public const int CountryMinLength = 5;
            public const int CountryMaxLength = 15;
     
        }

        public static class Invoice
        {
            public const string NumberMin = "1000000000";
            public const string NumberMax = "1500000000";
        }

        public static class Client
        {
            public const int NameMinLength = 10;
            public const int NameMaxLength = 25;

            public const int NumberVatMinLength = 10;
            public const int NumberVatMaxLength = 15;
        }
    }
}
