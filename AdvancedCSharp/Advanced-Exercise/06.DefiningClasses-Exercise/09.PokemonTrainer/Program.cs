namespace _09.PokemonTrainer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Trainer> trainers = new();

            string input;
            while ((input = Console.ReadLine()) != "Tournament")
            {
                string[] data = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string name = data[0];
                string pokemonName = data[1];
                string pokemonElement = data[2];
                int pokemonHealth = int.Parse(data[3]);

                Pokemon pokemon = new(pokemonName, pokemonElement, pokemonHealth);
                Trainer trainer = new(name, pokemon);

                if (trainers.ContainsKey(name))
                {
                    trainers[name].Pokemons.Add(pokemon);
                    continue;
                }

                trainers[name] = trainer;
            }

            while ((input = Console.ReadLine()) != "End")
            {
                foreach (var (name,trainer) in trainers)
                {
                    trainer.Battle(input);
                }
            }

            trainers = trainers
                .OrderByDescending(x => x.Value.Badges)
                .ToDictionary(x => x.Key, x => x.Value);

            Console.WriteLine(string.Join('\n',trainers.Values));
        }
    }
}
