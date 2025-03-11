using _06.FoodShortage.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.FoodShortage
{
    public class Citizen : IIdentifiable, IBirthdate,IBuyer
    {
        public Citizen(string name, int age, string id, string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthdate = birthdate;
            this.Food = 0;
        }

        public string Name { get; }
        public int Age { get; }
        public string Id { get; }

        public string Birthdate { get; }

        public int Food { get; private set; }

        public void BuyFood()
        {
            this.Food += 10;
        }
    }
}
