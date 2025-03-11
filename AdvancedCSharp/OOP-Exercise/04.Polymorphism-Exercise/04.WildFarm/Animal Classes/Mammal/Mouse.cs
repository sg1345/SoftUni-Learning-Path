using _04.WildFarm.Abstraction;
using _04.WildFarm.Animal_Classes.Birds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.WildFarm.Animal_Classes.Mammal
{
    public class Mouse : Mammal, IAnimal
    {
        private const double _weightGainer = 0.1;
        public Mouse(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }

        public override void Eat(IFood foodType)
        {
            if (foodType is Vegetable or Fruit)
            {
                this.FoodEaten += foodType.Quantity;
                this.Weight += foodType.Quantity * _weightGainer;
                return;
            }

            Console.WriteLine($"{nameof(Mouse)} does not eat {foodType.GetType().Name}!");
        }

        public override string MakeSound()
        {
            return "Squeak";
        }
    }
}
