using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01_StudentSystem.Common
{
    public static class EntityValidation
    {
        public static class Student 
        {
            public const int NameMaxLength = 100;
        }

        public static class Course 
        {
            public const int NameMaxLength = 80;
            public const int DescriptionMaxLength = 2000;
            public const string PriceColumnType = "decimal(18, 4)";
        }

        public static class Resorce 
        {
            public const int NameMaxLength = 50;
            public const int UrlMaxLength = 2083;
        }

        public static class Homework
        {
            public const int ContentMaxLength = 2083;
        }
    }
}
