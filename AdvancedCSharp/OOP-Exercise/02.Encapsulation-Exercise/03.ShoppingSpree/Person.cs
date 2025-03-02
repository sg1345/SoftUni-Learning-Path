using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.ShoppingSpree
{
    public class Person
    {
        private decimal _money;
        private readonly List<Product> _products;
        public Person(string name, decimal money)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name cannot be empty");
            }

            this.Name = name;
            this.Money = money;
            this._products = new List<Product>();
            this.Products = this._products.AsReadOnly();
        }

        public string Name { get; }
        public decimal Money
        {
            get => _money;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                _money = value;
            }
        }

        public IReadOnlyCollection<Product> Products { get; }

        public bool Buy(Dictionary<string, Product> catalogue, string productToBuy)
        {
            if (catalogue.ContainsKey(productToBuy) && catalogue[productToBuy].Cost <= this.Money)
            {
                this.Money -= catalogue[productToBuy].Cost;
                this._products.Add(catalogue[productToBuy]);

                return true;
                //Console.WriteLine($"{this.Name} bought {productToBuy}");
            }
            //else if (catalogue.ContainsKey(productToBuy) && catalogue[productToBuy].Cost > this.Money)
            //{
            //   Console.WriteLine($"{this.Name} can't afford {productToBuy}");
            //}
                return false;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{this.Name} - ");

            if (_products.Count > 0)
                sb.Append(string.Join(", ", _products));
            else
                sb.Append("Nothing bought");

            return sb.ToString();
        }
    }
}
