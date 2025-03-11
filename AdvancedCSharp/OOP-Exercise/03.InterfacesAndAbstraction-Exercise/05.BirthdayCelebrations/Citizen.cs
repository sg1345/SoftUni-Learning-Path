using _05.BirthdayCelebrations.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.BirthdayCelebrations
{
    public class Citizen : IIdentifiable, IBirthdate
    {
        public Citizen(string name, int age, string id, string birthdate)
        {
            Name = name;
            Age = age;
            Id = id;
            Birthdate = birthdate;
        }

        public string Name { get; }
        public int Age { get; }
        public string Id { get; }

        public string Birthdate { get; }
    }
}
