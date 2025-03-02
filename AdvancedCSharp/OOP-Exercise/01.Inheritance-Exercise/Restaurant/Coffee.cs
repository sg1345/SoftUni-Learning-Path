using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        private const double CoffeeMililiters = 50;
        private const decimal CoffeePrice = 3.50m;

        public Coffee(string name, double caffeine) 
            : base(name, CoffeePrice, CoffeeMililiters)
        {
            this.Caffeine = caffeine;
        }

        //public double CoffeeMililiters =>_coffeeMililiters;
        //public decimal CoffeePrice => _coffeePrice;
        public double Caffeine {  get; }
    }
}
