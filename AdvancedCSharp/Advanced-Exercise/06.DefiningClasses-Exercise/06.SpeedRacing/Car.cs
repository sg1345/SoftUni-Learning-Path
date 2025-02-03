using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.SpeedRacing
{
    internal class Car
    {
        private string _model;
        private double _fuelAmount;
        private double _fuelConsumptionPerKilometer;//per 1 km
        private double _travelledDistance;

        public Car()
        {
            this.Model = "Empty";
            this.FuelAmount = 0;
            this.FuelConsumptionPerKilometer = 0;
            this.TravelledDistance = 0;
        }
        public Car(string model, double fuelAmount, double fuelConsumptionPerKilometer) : this()
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
        }

        public string Model
        {
            get { return _model; }
            set { _model = value; }
        }
        public double FuelAmount
        {
            get { return _fuelAmount; }
            set { _fuelAmount = value; }
        }
        public double FuelConsumptionPerKilometer
        {
            get { return _fuelConsumptionPerKilometer; }
            set { _fuelConsumptionPerKilometer = value; }
        }
        public double TravelledDistance
        {
            get { return _travelledDistance; }
            set { _travelledDistance = value; }
        }


        public void Drive(double amountOfKilometers)
        {
            if (amountOfKilometers <= this.FuelAmount / this.FuelConsumptionPerKilometer)
            {
                this.TravelledDistance += amountOfKilometers;
                this.FuelAmount -= amountOfKilometers * this.FuelConsumptionPerKilometer;
                return;
            }

            Console.WriteLine("Insufficient fuel for the drive");
        }

        public void Print()
        {
            Console.WriteLine($"{this.Model} {this.FuelAmount:f2} {this.TravelledDistance}");
        }
    }
}
