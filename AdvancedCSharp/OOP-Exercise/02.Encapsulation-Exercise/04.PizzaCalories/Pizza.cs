using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.PizzaCalories
{
    public class Pizza
    {
        private double _totalCalories;
        private readonly List<Topping> _toppings;
        public Pizza(string name, Dough dough)
        {
            if(string.IsNullOrWhiteSpace(name) || name.Length<1 || name.Length>15)
            {
                throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
            }

            this.Name = name;
            this.Dough = dough;
            this._toppings = new List<Topping>();
            this.Toppings = this._toppings.AsReadOnly();
            this.TotalCalories = this.Dough.Calories;
        }

        public string Name { get; }
        public Dough Dough { get; set; }
        public IReadOnlyCollection<Topping> Toppings { get; }
        public double TotalCalories
        {
            get => this._totalCalories;
            private set
            {
                this._totalCalories = value;
            }
        }

        public void AddTopping(Topping topping)
        {
            if (this.Toppings.Count >= 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }
            this._toppings.Add(topping);
            this.TotalCalories += topping.Calories;
        }
        public override string ToString()
        {
            return $"{this.Name} - {this.TotalCalories:f2} Calories.";
        }
    }
}
