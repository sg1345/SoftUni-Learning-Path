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

            public const decimal PriceMin = 5.00m;
            public const decimal PriceMax = 1000.00m;
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
            public const int NumberMin = 1_000_000_000;
            public const int NumberMax = 1_500_000_000;
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
