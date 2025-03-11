using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.VehiclesExtension
{
    public class Truck : IVehicle
    {
        private const double _airConditionerConsumption = 1.6;

        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity)
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

            if (fuelToBeConsumed > FuelQuantity)
            {
                Console.WriteLine($"{nameof(Truck)} needs refueling");
                return;
            }

            FuelQuantity -= fuelToBeConsumed;

            Console.WriteLine($"{nameof(Truck)} travelled {distance} km");
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

            this.FuelQuantity += liters * 0.95;
        }

        public override string ToString()
        {
            return $"{nameof(Truck)}: {FuelQuantity:F2}";
        }
    }
}
