using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.PokemonTrainer
{
    public class Pokemon
    {
        private string _name;
        private string _element;
        private int _health;

        public Pokemon(string name, string element, int health)
        {
            this.Name = name;
            this.Element = element;
            this.Health = health;
        }

        public string Name { get { return this._name; } set { this._name = value; } }
        public string Element { get { return this._element; } set { this._element = value; } }
        public int Health
        {
            get { return this._health; }
            set { this._health = value; }
        }
    }
}
