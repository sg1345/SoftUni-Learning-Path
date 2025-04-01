using CyberSecurityDS.Models.Contracts;
using CyberSecurityDS.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberSecurityDS.Repositories
{
    public class CyberAttackRepository : IRepository<ICyberAttack>
    {
        private List<ICyberAttack> models;

        public CyberAttackRepository()
        {
            this.models = new List<ICyberAttack>();
        }

        public IReadOnlyCollection<ICyberAttack> Models => models.AsReadOnly();

        public void AddNew(ICyberAttack model) => models.Add(model);

        public bool Exists(string name) => this.Models.Any(a => a.AttackName == name);

        public ICyberAttack GetByName(string name) => Models.FirstOrDefault(a => a.AttackName == name);
    }
}
