using _05.BirthdayCelebrations.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.BirthdayCelebrations
{
    public class Pet : IBirthdate
    {
        public Pet(string name, string birthdate)
        {
            this.Name = name;
            this.Birthdate = birthdate;
        }

        public string Name { get; }
        public string Birthdate { get; }
    }
}
