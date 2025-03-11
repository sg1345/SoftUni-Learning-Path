using _04.WildFarm.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.WildFarm
{
    public class Fruit : IFood
    {
        public Fruit(int quantity)
        {
            Quantity = quantity;
        }

        public int Quantity { get; }
    }
}
