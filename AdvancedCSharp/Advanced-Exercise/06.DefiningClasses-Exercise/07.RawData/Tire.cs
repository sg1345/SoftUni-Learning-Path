using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.RawData
{
    public class Tire
    {
        private double _pressure;
        private int _age;

        public Tire()
        {

        }
        public Tire(double pressure, int age)
        {
            Age = age;
            Pressure = pressure;
        }

        public double Pressure { get { return this._pressure; } set { this._pressure = value; } }
        public int Age { get { return this._age; } set { this._age = value; } }
    }
}
