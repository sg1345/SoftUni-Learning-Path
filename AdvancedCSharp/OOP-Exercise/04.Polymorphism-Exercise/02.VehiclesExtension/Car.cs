using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.VehiclesExtension
{
    public class Car : IVehicle
    {
        private const double _airConditionerConsumption = 0.9;

        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            if (tankCapacity < fuelQuantity)
            {
                this.FuelQuantity = 0;
            }
            else
            {
                this.FuelQuantity = fuelQuantity;
            }

            this.FuelConsumption = fuelConsumption;
            this.TankCapacity = tankCapacity;
        }

        public double FuelQuantity { get; private set; }

        public double FuelConsumption { get; }

        public double TankCapacity { get; }

        public void Drive(double distance)
        {
            double fuelToBeConsumed = distance * (FuelConsumption + _airConditionerConsumption);

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
            if (liters <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
                return;
            }

            if (liters > this.TankCapacity - this.FuelQuantity)
            {
                Console.WriteLine($"Cannot fit {liters} fuel in the tank");
                return;
            }

            this.FuelQuantity += liters;
        }

        public override string ToString()
        {
            return $"{nameof(Car)}: {FuelQuantity:F2}";
        }
    }
}
