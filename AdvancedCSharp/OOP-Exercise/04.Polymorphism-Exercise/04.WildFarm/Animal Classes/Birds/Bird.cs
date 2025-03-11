using _04.WildFarm.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.WildFarm.Animal_Classes
{
    public abstract class Bird : IAnimal
    {
        public Bird(string name, double weight, double wingSize)
        {
            Name = name;
            Weight = weight;
            WingSize = wingSize;
            FoodEaten = 0;
        }

        public string Name { get; }

        public double Weight { get; protected set; }

        public double WingSize { get; }
        public int FoodEaten { get; protected set; }


        public abstract void Eat(IFood foodType);

        public abstract string MakeSound();

        public override string ToString() 
            => $"{GetType().Name} [{this.Name}, {this.WingSize}, {this.Weight}, {this.FoodEaten}]";
    }
}
