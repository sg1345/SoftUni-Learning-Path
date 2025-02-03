using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.RawData
{
    public class Engine
    {
        private int _speed;
        private int _power;

        public Engine(int speed, int power)
        {
            Speed = speed;
            Power = power;
        }

        public int Speed { get { return this._speed; } set { this._speed = value; } }
        public int Power { get { return this._power; } set { this._power = value; } }
    }
}
