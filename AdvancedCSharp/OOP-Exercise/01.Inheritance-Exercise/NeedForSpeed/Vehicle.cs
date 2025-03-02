using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeedForSpeed
{
    public class Vehicle
    {
        private const double DefaultFuelConsumption = 1.25;

        public Vehicle(int horsePower, double fuel)
        {
            Fuel = fuel;
            HorsePower = horsePower;
        }

        public virtual double Fuelconsumption { get; } = DefaultFuelConsumption;
        public double Fuel {  get; set; }
        public int HorsePower { get; }

        public virtual void Drive(double kilometers)
        {
            this.Fuel -= this.Fuelconsumption * kilometers;
        }
    }
}
