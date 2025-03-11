using _06.FoodShortage.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.FoodShortage
{
    public class Pet : IBirthdate
    {
        public Pet(string name, string birthdate)
        {
            Name = name;
            Birthdate = birthdate;
        }

        public string Name { get; }
        public string Birthdate { get; }
    }
}
