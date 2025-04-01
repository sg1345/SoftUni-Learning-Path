using CyberSecurityDS.Models.Contracts;
using CyberSecurityDS.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberSecurityDS.Repositories
{
    public class DefensiveSoftwareRepository : IRepository<IDefensiveSoftware>
    {
        private List<IDefensiveSoftware> models;

        public DefensiveSoftwareRepository()
        {
            this.models = new List<IDefensiveSoftware>();
        }

        public IReadOnlyCollection<IDefensiveSoftware> Models => models.AsReadOnly();

        public void AddNew(IDefensiveSoftware model) => models.Add(model);

        public bool Exists(string name) => this.Models.Any(a => a.Name == name);

        public IDefensiveSoftware GetByName(string name) => Models.FirstOrDefault(a => a.Name == name);
    }
}
