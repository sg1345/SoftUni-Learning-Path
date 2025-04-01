using BlackFriday.Models;
using BlackFriday.Models.Contracts;
using BlackFriday.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackFriday.Repositories
{
    class ProductRepository : IRepository<IProduct>
    {
        private List<IProduct> models;

        public ProductRepository()
        {
            this.models = new List<IProduct>();
        }

        public IReadOnlyCollection<IProduct> Models { get { return models.AsReadOnly(); } }

        public void AddNew(IProduct model)
        {
            this.models.Add(model);
        }

        public bool Exists(string name)
            => Models.Any(p => p.ProductName == name);

        public IProduct GetByName(string name)
            => Models.FirstOrDefault(p => p.ProductName == name);
    }
}
