using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Raiding
{
    public abstract class BaseHero
    {       
        public string Name { get; }

        protected BaseHero(string name)
        {
            Name = name;
        }

        public abstract int Power { get; }

        public abstract string CastAbility();
    }
}
