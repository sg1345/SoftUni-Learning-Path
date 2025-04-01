using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheContentDepartment.Utilities.Messages;

namespace TheContentDepartment.Models
{
    public class TeamLead : TeamMember
    {
        private const string allowedPath = "Master";
        public TeamLead(string name, string path) : base(name, path)
        {
            if(path != allowedPath)
                throw new ArgumentException(string.Format(ExceptionMessages.PathIncorrect, path));
        }

        public override string ToString()
        {
            string objectTypeName = this.GetType().Name;

            return $"{Name} ({objectTypeName}) - Currently working on {InProgress.Count} tasks.";
        }
    }
}
