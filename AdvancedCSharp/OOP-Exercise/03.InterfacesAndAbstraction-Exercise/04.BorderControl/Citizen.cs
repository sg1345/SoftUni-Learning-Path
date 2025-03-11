using _04.BorderControl.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.BorderControl
{
    public class Citizen : IIdentifiable
    {
        public Citizen(string name, int age, string id)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
        }

        public string Name { get; }
        public int Age { get; }
        public string Id { get; }
    }
}
