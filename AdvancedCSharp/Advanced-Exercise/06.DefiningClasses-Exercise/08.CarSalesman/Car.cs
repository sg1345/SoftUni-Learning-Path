using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.CarSalesman
{
    internal class Car
    {
        private string _model;
        private Engine _engine;
        private int _weight;
        private string _color;

        public Car(string model, Engine engine)
        {
            this.Model = model;
            this.Engine = engine;
        }
        public Car(string model, Engine engine, int weight) : this(model, engine)
        {
            this.Weight = weight;
        }    
        public Car(string model, Engine engine, string color) : this(model, engine)
        {
            this.Color = color;
        }
        public Car(string model, Engine engine, int weight, string color) : this(model, engine, weight)
        {
            this.Color = color;
        }

        public string Model { get { return this._model; } set { this._model = value; } }
        public Engine Engine { get { return this._engine; } set { this._engine = value; } }
        public int Weight { get { return this._weight; } set { this._weight = value; } }
        public string Color { get { return this._color; } set { this._color = value; } }

        public void Print()
        {
            Console.WriteLine($"{this.Model}:");
            Console.WriteLine($"  {this.Engine.Model}:");
            Console.WriteLine($"    Power: {this.Engine.Power}");

            if (this.Engine.Displacement == 0)
            {
                Console.WriteLine($"    Displacement: n/a");
            }
            else
            {
                Console.WriteLine($"    Displacement: {this.Engine.Power}");
            }

            if (this.Engine.Efficiency == null)
            {
                Console.WriteLine($"    Efficiency: n/a");
            }
            else
            {
                Console.WriteLine($"    Efficiency: {this.Engine.Efficiency}");
            }

            if (this.Weight == 0)
            {

            }
            else
            {
                Console.WriteLine($"  Weight: {this.Weight}");
            }

            if (this.Color == null)
            {

            }
            else
            {
                Console.WriteLine($"  Color: {this.Color}");
            }
        }

        public override string ToString()
        {
            //Func<string, string> funcString = x => x == null ? "n/a" : x;
            //Func<int, string> funcInt = x => x == 0 ? "n/a" : x.ToString();

            return $"{this.Model}:\n" +
                   $"  {this.Engine.Model}:\n" +
                   $"    Power: {this.Engine.Power}\n" +
                   $"    Displacement: {Checker(this.Engine.Displacement)}\n" +
                   $"    Efficiency: {Checker(this.Engine.Efficiency)}\n" +
                   $"  Weight: {Checker(this.Weight)}\n"+
                   $"  Color: {Checker(this.Color)}";
        }

        private string Checker<T>(T value)
        {

            return EqualityComparer<T>.Default.Equals(value, default(T)) ? "n/a" : value.ToString();            
        }
    }
}
