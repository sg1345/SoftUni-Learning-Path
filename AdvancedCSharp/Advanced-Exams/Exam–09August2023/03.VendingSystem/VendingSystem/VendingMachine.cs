using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VendingSystem
{
    public class VendingMachine
    {
        public VendingMachine(int buttonCapacity)
        {
            this.ButtonCapacity = buttonCapacity;
            this.Drinks = new List<Drink>();
        }

        public int ButtonCapacity { get; }
        public List<Drink> Drinks { get; set; }
        public int GetCount => this.Drinks.Count;

        public void AddDrink(Drink drink)
        {
            if (ButtonCapacity > this.Drinks.Count)
            {
                this.Drinks.Add(drink);
            }
        }

        public bool RemoveDrink(string drinkName)
            => this.Drinks.Remove(this.Drinks.FirstOrDefault(drink => drink.Name == drinkName));

        public Drink GetLongest() => this.Drinks.OrderByDescending(drink => drink.Volume).FirstOrDefault();

        public Drink GetCheapest() => this.Drinks.OrderBy(Drinks => Drinks.Price).FirstOrDefault();

        public string BuyDrink(string name)
            => this.Drinks.ElementAt(this.Drinks.FindIndex(drink => drink.Name == name)).ToString();

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Drinks available:");

            foreach(Drink drink in this.Drinks)
            {
                sb.AppendLine(drink.ToString());
            }
            return sb.ToString().Trim();
        }
    }
}
