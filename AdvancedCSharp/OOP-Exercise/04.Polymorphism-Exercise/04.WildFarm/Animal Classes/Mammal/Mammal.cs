using _04.WildFarm.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.WildFarm.Animal_Classes.Mammal
{
    public abstract class Mammal : IAnimal
    {
        public Mammal(string name, double weight,  string livingRegion)
        {
            Name = name;
            Weight = weight;
            LivingRegion = livingRegion;
            FoodEaten = 0;
        }

        public string Name { get; }

        public double Weight { get; protected set; }

        public int FoodEaten { get; protected set; }
        public string LivingRegion { get; }

        public abstract void Eat(IFood foodType);

        public abstract string MakeSound();

        public override string ToString() 
            => $"{GetType().Name} [{this.Name}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
    }
}
