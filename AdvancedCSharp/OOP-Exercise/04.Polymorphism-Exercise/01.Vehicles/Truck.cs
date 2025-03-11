using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Vehicles
{
    public class Truck : IVehicle
    {
        private const double AirConditionerConsumption = 1.6;

        public Truck(double fuelQuantity, double fuelConsumption)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity { get; private set; }

        public double FuelConsumption { get; }

        public void Drive(double distance)
        {
            double fuelToBeConsumed = distance * (FuelConsumption + AirConditionerConsumption);

            if (fuelToBeConsumed > this.FuelQuantity)
            {
                Console.WriteLine($"{nameof(Car)} needs refueling");
                return;
            }

            this.FuelQuantity -= fuelToBeConsumed;

            Console.WriteLine($"{nameof(Car)} travelled {distance} km");
        }

        public void Refuel(double liters)
        {
            this.FuelQuantity += liters * 0.95;
        }

        public override string ToString()
        {
            return $"{nameof(Truck)}: {this.FuelQuantity:F2}";
        }
    }
}
