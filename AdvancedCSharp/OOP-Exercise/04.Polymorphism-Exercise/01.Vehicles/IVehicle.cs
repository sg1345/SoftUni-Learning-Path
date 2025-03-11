using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Vehicles
{
    public interface IVehicle
    {
        public double FuelQuantity { get; }
        public double FuelConsumption { get; }       

        void Drive(double distance);

        void Refuel(double liters);

        
    }
}
