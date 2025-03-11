using _04.WildFarm.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.WildFarm.Animal_Classes.Birds
{
    public class Owl : Bird, IAnimal
    {
        private const double _weightGainer = 0.25;
        public Owl(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
        }

        public override void Eat(IFood foodType)
        {
            if (foodType is Meat)
            {
                this.FoodEaten += foodType.Quantity;
                this.Weight += foodType.Quantity * _weightGainer;
                return;
            }

            Console.WriteLine($"{nameof(Owl)} does not eat {foodType.GetType().Name}!");
        }

        public override string MakeSound()
        {
            return "Hoot Hoot";
        }
    }
}
