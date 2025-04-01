using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheContentDepartment.Models.Contracts;
using TheContentDepartment.Utilities.Messages;

namespace TheContentDepartment.Models
{
    public abstract class Resource : IResource
    {
        private string name;

        public Resource(string name, string creator, int priority)
        {
            Name = name;
            Creator = creator;
            Priority = priority;
            IsTested = false;
            IsApproved = false;
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhiteSpace);

                    name = value;
            }
        }

        public string Creator { get; }

        public int Priority { get; }

        public bool IsTested { get; private set; }

        public bool IsApproved { get; private set; }

        public void Approve()
        {
            IsApproved = true;
        }

        public void Test()
        {
            IsTested = !IsTested;
        }

        public override string ToString()
        {
            string objectTypeName = this.GetType().Name;

            return $"{Name} ({objectTypeName}), Created By: {Creator}";
        }
    }
}
