using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.CarSalesman
{
    public class Engine
    {
        private string _model;
        private int _power;
        private int _displacement;
        private string _efficiency;

        public Engine(string model, int power)
        {
            this.Model = model;
            this.Power = power;
        }
        public Engine(string model,int power, int displacement) : this(model, power) 
        {
            this.Displacement = displacement;
        }
        public Engine(string model,int power, string efficiency) : this(model, power) 
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
            get { return this._model; }
            set { this._model = value; }
        }
        public int Power
        {
            get { return this._power; }
            set { this._power = value; }
        }
        public int Displacement
        {
            get { return this._displacement; }
            set { this._displacement = value; }
        }
        public string Efficiency 
        { 
            get { return this._efficiency; } 
            set { this._efficiency = value; } 
        }
    }
}
