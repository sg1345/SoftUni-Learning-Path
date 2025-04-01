using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheContentDepartment.Utilities.Messages;

namespace TheContentDepartment.Models
{
    public class ContentMember : TeamMember
    {
        private readonly string[] allowedPaths = { "CSharp", "JavaScript", "Python", "Java" };
        private bool Exist = false;
        public ContentMember(string name, string path) : base(name, path)
        {
            foreach (string allowedPath in allowedPaths)
            {
                if (path == allowedPath)
                    Exist = true;
            }

            if (!Exist)
                throw new ArgumentException(string.Format(ExceptionMessages.PathIncorrect, path));
        }

        public override string ToString()
        {
            return $"{Name} - {Path} path. Currently working on {InProgress.Count} tasks.";
        }
    }
}
