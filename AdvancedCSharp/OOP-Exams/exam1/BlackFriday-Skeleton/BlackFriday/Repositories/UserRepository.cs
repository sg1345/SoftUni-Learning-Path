using BlackFriday.Models.Contracts;
using BlackFriday.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackFriday.Repositories
{
    public class UserRepository : IRepository<IUser>
    {
        private List<IUser> models;

        public UserRepository()
        {
            this.models = new List<IUser>();
        }

        public IReadOnlyCollection<IUser> Models { get { return models.AsReadOnly(); } }

        public void AddNew(IUser model)
        {
            this.models.Add(model);
        }

        public bool Exists(string name)
            => Models.Any(u => u.UserName == name);

        public IUser GetByName(string name)
            => Models.FirstOrDefault(u => u.UserName == name);
    }
}
