namespace _01.Solution
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> substances = new Stack<int>();
            Queue<int> crystals = new Queue<int>();

            for (int i = 0; i < 2; i++)
            {
                int[] numbers = Console.ReadLine()!
                    .Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int j = 0; j < numbers.Length; j++)
                {
                    if (i == 0)
                    {
                        substances.Push(numbers[j]);
                    }
                    else //if (i == 1)
                    {
                        crystals.Enqueue(numbers[j]);
                    }
                }
            }

            Dictionary<int, string> potionsToDo = new Dictionary<int, string>();
            potionsToDo[110] = "Brew of Immortality";
            potionsToDo[100] = "Essence of Resilience";
            potionsToDo[90] = "Draught of Wisdom";
            potionsToDo[80] = "Potion of Agility";
            potionsToDo[70] = "Elixir of Strength";

            List<string> completedPotions = new List<string>();
            bool areCrafted = false;
            bool hasLeftOvers = false;

            while (true)
            {
                int substance = substances.Pop();
                int energy = crystals.Dequeue();
                if (hasLeftOvers)
                {
                    substance *= 2;
                }
                hasLeftOvers = false;
                int combinedEnergy = substance + energy;

                if (potionsToDo.ContainsKey(combinedEnergy))
                {
                    completedPotions.Add(potionsToDo[combinedEnergy]);
                    potionsToDo.Remove(combinedEnergy);
                }
                else if (potionsToDo.Count > 0 && potionsToDo.Keys.Where(k => k < combinedEnergy).FirstOrDefault() != 0)
                {
                    int levelPotion = potionsToDo.Keys.Where(k => k < combinedEnergy).First();
                    completedPotions.Add(potionsToDo[levelPotion]);
                    potionsToDo.Remove(levelPotion);
                    hasLeftOvers = true;
                }

                crystals.Enqueue(0);

                if (potionsToDo.Count == 0)
                {
                    areCrafted = true;
                    break;
                }

                if (substances.Count == 0)
                {
                    break;
                }

                for (int j = 0; j < crystals.Count; j++)
                {
                    int temp = crystals.Dequeue() + 5;
                    crystals.Enqueue(temp);
                }
            }

            if (areCrafted)
            {
                Console.WriteLine("Success! The alchemist has forged all potions!");
            }
            else
            {
                Console.WriteLine("The alchemist failed to complete his quest.");
            }

            if (completedPotions.Count > 0)
            {
                Console.WriteLine($"Crafted potions: {string.Join(", ", completedPotions)}");
            }

            if (substances.Count > 0)
            {
                Console.WriteLine($"Substances: {string.Join(", ", substances)}");
            }

            Console.WriteLine($"Crystals: {string.Join(", ", crystals)}");
        }
    }
}