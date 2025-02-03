using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSalesman
{
    internal class Car
    {
        private string model;
        private Engine engine;
        private int weight;
        private string color;

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

        public string Model { get { return this.model; } set { this.model = value; } }
        public Engine Engine { get { return this.engine; } set { this.engine = value; } }
        public int Weight { get { return this.weight; } set { this.weight = value; } }
        public string Color { get { return this.color; } set { this.color = value; } }

        //public void Print()
        //{
        //    Console.WriteLine($"{this.Model}:");
        //    Console.WriteLine($"  {this.Engine.Model}:");
        //    Console.WriteLine($"    Power: {this.Engine.Power}");

        //    if (this.Engine.Displacement == 0)
        //    {
        //        Console.WriteLine($"    Displacement: n/a");
        //    }
        //    else
        //    {
        //        Console.WriteLine($"    Displacement: {this.Engine.Power}");
        //    }

        //    if (this.Engine.Efficiency == null)
        //    {
        //        Console.WriteLine($"    Efficiency: n/a");
        //    }
        //    else
        //    {
        //        Console.WriteLine($"    Efficiency: {this.Engine.Efficiency}");
        //    }

        //    if (this.Weight == 0)
        //    {

        //    }
        //    else
        //    {
        //        Console.WriteLine($"  Weight: {this.Weight}");
        //    }

        //    if (this.Color == null)
        //    {

        //    }
        //    else
        //    {
        //        Console.WriteLine($"  Color: {this.Color}");
        //    }
        //}

        //public override string ToString()
        //{
        //    StringBuilder resultBuilder = new StringBuilder();

        //    resultBuilder.AppendLine($"{this.Model}:");
        //    resultBuilder.AppendLine(this.Engine.ToString());
        //    resultBuilder.AppendLine($"  Weight: {Checker(this.Weight)}");
        //    resultBuilder.Append($"  Color: {Checker(this.Color)}");

        //    return resultBuilder.ToString();
        //}
        public override string ToString()
        {
            return $"{this.Model}:\n"+
                        this.Engine.ToString()+ "\n" +
                   $"  Weight: {Checker(this.Weight)}\n"+
                   $"  Color: {Checker(this.Color)}";
        }

        private string Checker<T>(T value)
        {
            return EqualityComparer<T>.Default.Equals(value, default(T)) ? "n/a" : value.ToString();
        }
    }
}
