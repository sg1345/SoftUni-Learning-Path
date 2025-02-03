using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.RawData
{
    public class Cargo
    {
        private int _weight;
        private string _type;

        public Cargo(int weight, string type)
        {
            Weight = weight;
            Type = type;
        }

        public int Weight { get { return this._weight; } set { this._weight = value; } }
        public string Type { get { return this._type; } set { this._type = value; } }

    }
}
