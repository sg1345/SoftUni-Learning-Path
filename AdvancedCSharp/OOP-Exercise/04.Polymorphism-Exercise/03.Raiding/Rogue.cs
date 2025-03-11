using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Raiding
{
    public class Rogue : BaseHero
    {
        private const int _power = 80;
        public Rogue(string name) : base(name)
        {
        }

        public override int Power { get; } = _power;

        public override string CastAbility()
        {
            return $"{nameof(Rogue)} - {this.Name} hit for {this.Power} damage";
        }
    }
}
