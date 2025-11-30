using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Common
{
    public class EntityValidation
    {
        public static class User
        {
            public const int MinUsernameLength = 4;
            public const int MaxUsernameLength = 20;

            public const int MinEmailLength = 8;
            public const int MaxEmailLength = 60;

            public const int MinPasswordLength = 6;
        }

        public static class Conversation
        {
            public const int MinTitleLength = 2;
            public const int MaxTitleLength = 30;
        }

        public static class Post
        {
            public const int MinContentLength = 5;
            public const int MaxContentLength = 300;
        }

        public static class Message
        {
            public const int MinContentLength = 1;
            public const int MaxContentLength = 200;
        }
    }
}
