using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.PokemonTrainer
{
    internal class Trainer
    {
        private string _name;
        private int _badges;
        private List<Pokemon> _Pokemons = new();

        public Trainer()
        {
            this.Badges = 0;
        }
        public Trainer(string name, Pokemon pokemon) : this()
        {
            this.Name = name;
            this.Pokemons.Add(pokemon);
        }

        public string Name { get { return this._name; } set { this._name = value; } }
        public int Badges
        { get { return this._badges; } set { this._badges = value; } }
        public List<Pokemon> Pokemons
        { get { return this._Pokemons; } set { this._Pokemons = value; } }


        public void Battle(string element)
        {
            bool containsTheRgithPokemon =
                this.Pokemons.Where(Pokemon => Pokemon.Element == element).Any();

            if (containsTheRgithPokemon)
            {
                this.Badges++;
                return;
            }

            //this.Pokemons = this.Pokemons
            //    .Select(pokemon => new Pokemon(pokemon.Name, pokemon.Element, pokemon.Health - 10))
            //    .Where(pokemon => pokemon.Health > 0)
            //    .ToList();

            this.Pokemons.ForEach(pokemon => pokemon.Health -= 10);
            this._Pokemons.RemoveAll(pokemon => pokemon.Health <= 0);
        }

        public override string ToString()
        {
            return $"{this.Name} {this.Badges} {this.Pokemons.Count}";
        }
    }
}
