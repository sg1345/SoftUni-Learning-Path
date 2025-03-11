using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.WildFarm.Abstraction
{
    public interface IAnimal
    {
        string Name { get; }
        double Weight { get; }
        int FoodEaten { get; }

        string MakeSound();
        void Eat(IFood foodType);
    }
}
