using _04.WildFarm.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.WildFarm.Animal_Classes.Mammal.Feline
{
    public abstract class Feline : Mammal, IAnimal
    {
        public Feline(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion)
        {
            Breed = breed;
        }

        public string Breed { get; }

        //public override abstract string MakeSound();

        public override string ToString() 
            => $"{GetType().Name} [{this.Name}, {this.Breed}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
    }
}
