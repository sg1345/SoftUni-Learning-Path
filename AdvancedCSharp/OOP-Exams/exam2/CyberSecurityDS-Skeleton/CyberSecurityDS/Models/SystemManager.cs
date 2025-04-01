using CyberSecurityDS.Models.Contracts;
using CyberSecurityDS.Repositories;
using CyberSecurityDS.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberSecurityDS.Models
{
    public class SystemManager : ISystemManager
    {
        private IRepository<ICyberAttack> cyberAttacks;
        private IRepository<IDefensiveSoftware> defensiveSoftware;

        public SystemManager()
        {
            this.cyberAttacks = new CyberAttackRepository();
            this.defensiveSoftware = new DefensiveSoftwareRepository();
        }

        public IRepository<ICyberAttack> CyberAttacks => cyberAttacks;

        public IRepository<IDefensiveSoftware> DefensiveSoftwares => defensiveSoftware;
    }
}
