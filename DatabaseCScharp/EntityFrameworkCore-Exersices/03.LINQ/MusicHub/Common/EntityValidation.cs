using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicHub.Common
{
    public static class EntityValidation
    {
        public static class Song
        {
            public const int NameLength = 20;
        }

        public static class Album
        {
            public const int NameLength = 20;
        }

        public static class Performer
        {
            public const int FirstNameLength = 20;
            public const int LastNameLength = 20;
        }

        public static class Producer
        {
            public const int NameLength = 30;
            public const int PseudonymLength = 746;
            public const int PhoneNumberLength = 16;
        }

        public static class Writer
        {
            public const int NameLength = 20;
            public const int PseudonymLength = 746;
        }
    }
}
