using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.PizzaCalories
{
    public class Topping
    {
        private readonly Dictionary<string, double> _caloriesForTopping = new (StringComparer.OrdinalIgnoreCase)
        {
            ["meat"] = 1.2,
            ["veggies"] = 0.8,
            ["cheese"] = 1.1,
            ["sauce"] = 0.9
        };

        public Topping(string type, double grams)
        {
            if (!this.ToppingIsAvailable(type))
            {
                throw new ArgumentException($"Cannot place {type} on top of your pizza.");
            }

            if (grams < 1 || grams > 50)
            {
                throw new ArgumentException($"{type} weight should be in the range [1..50].");
            }

            this.Type = type;
            this.Grams = grams;
            this.Calories = CaloriesCalculator();
        }

        public string Type { get; }
        public double Grams { get; }
        public double Calories { get; }

        private double CaloriesCalculator()
            => 2 * this.Grams * this._caloriesForTopping[this.Type];
        
        private bool ToppingIsAvailable(string type)
        => this._caloriesForTopping.ContainsKey(type);        

    }
}
