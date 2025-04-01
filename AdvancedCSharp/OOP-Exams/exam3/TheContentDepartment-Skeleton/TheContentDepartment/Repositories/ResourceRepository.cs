using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheContentDepartment.Models.Contracts;
using TheContentDepartment.Repositories.Contracts;

namespace TheContentDepartment.Repositories
{
    public class ResourceRepository : IRepository<IResource>
    {
        private List<IResource> _models;

        public ResourceRepository()
        {
            _models = new List<IResource>();
        }

        public IReadOnlyCollection<IResource> Models => _models.AsReadOnly();

        public void Add(IResource model)
        {
            _models.Add(model);
        }

        public IResource TakeOne(string modelName) => _models.FirstOrDefault(m => m.Name == modelName);
    }
}
