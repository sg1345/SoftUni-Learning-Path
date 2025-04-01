using BlackFriday.Models.Contracts;
using BlackFriday.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackFriday.Models
{
    public abstract class User : IUser
    {
        private string userName;
        private string email;

        protected User(string userName, string email, bool hasDataAccess)
        {
            UserName = userName;
            Email = email;
            HasDataAccess = hasDataAccess;
        }

        public string UserName
        {
            get { return userName; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(ExceptionMessages.UserNameRequired);

                userName = value;
            }
        }

        public string Email
        {
            get
            {
                if (HasDataAccess)
                {
                    return "hidden";
                }
                else
                {
                    return email;
                }
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(ExceptionMessages.EmailRequired);

                email = value;
            }
        }

        public bool HasDataAccess { get; }

        public override string ToString()
        {
            string type = this.GetType().Name;
            return $"{UserName} - Status: {type}, Contact Info: {Email}";
        }
    }
}
