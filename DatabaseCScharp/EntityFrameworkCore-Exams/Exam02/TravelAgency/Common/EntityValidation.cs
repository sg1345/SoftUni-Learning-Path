using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.Common
{
    public static class EntityValidation
    {
        public static class Customer
        {
            public const int FullNameMinLength = 4;
            public const int FullNameMaxLength = 60;

            public const int EmailMinLength = 6;
            public const int EmailMaxLength = 50;

            public const int PhoneNumberLength = 13;
            public const string PhoneNumberRegex = @"^\+\d{12}$";
        }

        public static class Guide
        {
            public const int FullNameMinLength = 4;
            public const int FullNameMaxLength = 60;
        }

        public static class TourPackage
        {
            public const int PackageNameMinLength = 2;
            public const int PackageNameMaxLength = 40;

            public const int DescriptionMaxLength = 200;

            public const string PriceMin = "0.01"; 
        }
    }
}
