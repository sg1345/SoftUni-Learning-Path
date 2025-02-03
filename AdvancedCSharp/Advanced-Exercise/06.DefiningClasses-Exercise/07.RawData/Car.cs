using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.RawData
{
    internal class Car
    {
        private string _model;
        private Engine _engine;
        private Cargo _cargo;
        private Tire[] _tires = new Tire[4];

        public Car(string model)
        {
            Model = model;
        }
        public Car(string model, Engine engine, Cargo cargo, Tire[] tires) : this(model)
        {
            Engine = engine;
            Cargo = cargo;
            Tires = tires;
        }
        public Car(string model, int engineSpeed, int enginePower, int cargoWeight, string cargoType,
            double tireOnePressure, int tireOneAge, double tireTwoPressure, int tireTwoAge,
            double tireThreePressure, int tireThreeAge, double tireFourPressure, int tireFourAge)
            : this(model)
        {
            Engine = new(engineSpeed, enginePower);

            Cargo = new(cargoWeight, cargoType);

            Tires[0] = new(tireTwoPressure, tireOneAge);
            Tires[1] = new(tireTwoPressure, tireTwoAge);
            Tires[2] = new(tireThreePressure, tireThreeAge);
            Tires[3] = new(tireFourPressure, tireFourAge);
        }

        public string Model { get { return this._model; } set { this._model = value; } }
        public Engine Engine { get { return this._engine; } set { this._engine = value; } }
        public Cargo Cargo { get { return this._cargo; } set { this._cargo = value; } }
        public Tire[] Tires { get { return this._tires; } set { this._tires = value; } }

        public void PrintModelFiteredByCargo(string command)
        {
            Car car = new(this.Model, this.Engine, this.Cargo, this.Tires);

            Func<Car, bool> filter = Filter(command);

            if (filter(car))
            {
                Console.WriteLine(car.Model);
            }
        }

        private Func<Car, bool> Filter(string command)
        {
            return command switch
            {
                "fragile" => x =>
                {
                    return x.Cargo.Type == command && x.Tires.Any(tire => tire.Pressure < 1);
                },

                "flammable" => x =>
                {
                    return x.Cargo.Type == command && x.Engine.Power > 250;
                },
            };
        }
    }
}
