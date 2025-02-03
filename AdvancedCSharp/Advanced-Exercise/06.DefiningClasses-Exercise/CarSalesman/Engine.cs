using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSalesman
{
    public class Engine
    {
        private string model;
        private int power;
        private int displacement;
        private string efficiency;

        public Engine(string model, int power)
        {
            this.Model = model;
            this.Power = power;
        }
        public Engine(string model, int power, int displacement) : this(model, power)
        {
            this.Displacement = displacement;
        }
        public Engine(string model, int power, string efficiency) : this(model, power)
        {
            this.Efficiency = efficiency;
        }
        public Engine(string model, int power, int displacement, string efficiency)
            : this(model, power, displacement)
        {
            this.Efficiency = efficiency;
        }

        public string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }
        public int Power
        {
            get { return this.power; }
            set { this.power = value; }
        }
        public int Displacement
        {
            get { return this.displacement; }
            set { this.displacement = value; }
        }
        public string Efficiency
        {
            get { return this.efficiency; }
            set { this.efficiency = value; }
        }

        //public override string ToString()
        //{
        //    StringBuilder resultBuilder = new StringBuilder();

        //    resultBuilder.AppendLine($"  {this.Model}:");
        //    resultBuilder.AppendLine($"    Power: {this.Power}");
        //    resultBuilder.AppendLine($"    Displacement: {Checker(this.Displacement)}");
        //    resultBuilder.Append($"    Efficiency: {Checker(this.Efficiency)}");

        //    return resultBuilder.ToString();
        //}
        public override string ToString()
        {
           
           return $"  {this.Model}:\n"+
                  $"    Power: {this.Power}\n"+
                  $"    Displacement: {Checker(this.Displacement)}\n"+
                  $"    Efficiency: {Checker(this.Efficiency)}";

            
        }
        private string Checker<T>(T value)
        {
            return EqualityComparer<T>.Default.Equals(value, default(T)) ? "n/a" : value.ToString();
        }
    }
}
