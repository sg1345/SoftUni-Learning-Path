using _04.WildFarm.Abstraction;
using _04.WildFarm.Animal_Classes.Birds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.WildFarm.Animal_Classes.Mammal.Feline
{
    public class Cat : Feline, IAnimal
    {
        private const double _weightGainer = 0.3;
        public Cat(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }

        public override void Eat(IFood foodType)
        {
            if (foodType is Vegetable or Meat)
            {
                this.FoodEaten += foodType.Quantity;
                this.Weight += foodType.Quantity * _weightGainer;
                return;
            }

            Console.WriteLine($"{nameof(Cat)} does not eat {foodType.GetType().Name}!");
        }

        public override string MakeSound()
        {
            return "Meow";
        }
    }
}
