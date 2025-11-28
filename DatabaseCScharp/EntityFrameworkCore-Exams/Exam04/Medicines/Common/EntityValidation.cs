using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicines.Common
{
    public class EntityValidation
    {
        public static class Pharmacy
        {
            public const int NameMinLength = 2;
            public const int NameMaxLength = 50;

            public const int PhoneNumberLength = 14;
            public const string PhoneNumberRegex = @"^\(\d{3}\) \d{3}-\d{4}$";
        }

        public static class Medicine
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 150;

            public const string PriceTypeName = "decimal(6,2)";
            public const string PriceMin = "0.01";
            public const string PriceMax = "1000.00";

            public const int ProducerMinLength = 3;
            public const int ProducerMaxLength = 100;
        }

        public static class Patient
        {
            public const int FullNameMinLength = 5;
            public const int FullNameMaxLength = 100;
        }
    }
}
