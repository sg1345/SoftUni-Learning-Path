using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Vehicles
{
    public class Car : IVehicle
    {
        private const double AirConditionerConsumption = 0.9;

        public Car(double fuelQuantity, double fuelConsumption)
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
            this.FuelQuantity += liters;
        }

        public override string ToString()
        {
            return $"{nameof(Car)}: {this.FuelQuantity:F2}";
        }
    }
}
