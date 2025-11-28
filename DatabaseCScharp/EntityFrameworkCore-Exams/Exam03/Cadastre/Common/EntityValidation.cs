using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastre.Common
{
    public static class EntityValidation
    {
        public static class District
        {
            public const int NameMinLength = 2;
            public const int NameMaxLength = 80;

            public const int PostalCodeLength = 8;
            public const string PostalCodeRegex = @"^[A-Z]{2}-\d{5}$";
        }

        public static class Property
        {
            public const int PropertyIdentifierMinLength = 16;
            public const int PropertyIdentifierMaxLength = 20;

            public const int DetailsMinLength = 5;
            public const int DetailsMaxLength = 500;

            public const int AddressMinLength = 5;
            public const int AddressMaxLength = 200;

        }

        public static class Citizen
        {
            public const int FirstNameMinLength = 2;
            public const int FirstNameMaxLength = 30;

            public const int LastNameMinLength = 2;
            public const int LastNameMaxLength = 30;
        }


    }
}
