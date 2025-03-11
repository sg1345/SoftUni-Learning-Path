using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Raiding
{
    public class Warrior : BaseHero
    {
        private const int _power = 100;
        public Warrior(string name) : base(name)
        {
        }

        public override int Power { get; } = _power;

        public override string CastAbility()
        {
            return $"{nameof(Warrior)} - {this.Name} hit for {this.Power} damage";
        }
    }
}
