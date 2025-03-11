using _04.WildFarm.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.WildFarm.Animal_Classes.Birds
{
    public class Hen : Bird, IAnimal
    {
        private const double _weightGainer = 0.35;
        public Hen(string name, double weight,  double wingSize) 
            : base(name, weight, wingSize)
        {
        }

        public override void Eat(IFood foodType)
        {
                this.FoodEaten += foodType.Quantity;
                this.Weight += foodType.Quantity * _weightGainer;
        }

        public override string MakeSound()
        {
            return "Cluck";
        }
    }
}
