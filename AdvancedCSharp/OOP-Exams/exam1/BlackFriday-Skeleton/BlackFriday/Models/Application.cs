using BlackFriday.Models.Contracts;
using BlackFriday.Repositories;
using BlackFriday.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackFriday.Models
{
    public class Application : IApplication
    {
        private IRepository<IProduct> product;
        private IRepository<IUser> user;

        public Application()
        {
            this.product = new ProductRepository();
            this.user = new UserRepository();
        }

        public IRepository<IProduct> Products { get { return product; } }

        public IRepository<IUser> Users { get { return user; } }
    }
}
