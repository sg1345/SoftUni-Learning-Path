namespace _01.WildSurvival
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> bees = new Queue<int>();
            Stack<int> beeEaters = new Stack<int>();

            PreparingForTheBattle(bees, beeEaters);

            while (bees.Count > 0 && beeEaters.Count > 0)
            {
                int defence = bees.Dequeue();
                int attack = beeEaters.Pop() * 7;

                if (defence > attack)
                {
                    bees.Enqueue(defence - attack);
                }
                else if (defence < attack)
                {
                    int plusOneSurvived = 0;
                    if ((attack - defence) % 7 != 0)
                    {
                        plusOneSurvived++;
                    }
                        int survived = ((attack - defence) / 7) + plusOneSurvived;

                    int newGroupOfbeeEaters = 0;
                    if (beeEaters.Count > 0)
                    {
                        newGroupOfbeeEaters = beeEaters.Pop() + survived;
                    }
                    else // Count==0
                    {
                        newGroupOfbeeEaters = survived;
                    }
                    beeEaters.Push(newGroupOfbeeEaters);
                }
            }

            Console.WriteLine("The final battle is over!");

            if (bees.Count > 0 && beeEaters.Count == 0)
            {
                Console.WriteLine($"Bee groups left: {string.Join(", ", bees)}");
            }
            else if (beeEaters.Count > 0 && bees.Count == 0)
            {
                Console.WriteLine($"Bee-eater groups left: {string.Join(", ", beeEaters)}");
            }
            else
            {
                Console.WriteLine("But no one made it out alive!");
            }
        }

        private static void PreparingForTheBattle(Queue<int> bees, Stack<int> beeEaters)
        {
            for (int i = 0; i < 2; i++)
            {
                int[] input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int j = 0; j < input.Length; j++)
                {
                    if (i == 0)
                    {
                        bees.Enqueue(input[j]);
                    }
                    else
                    {
                        beeEaters.Push(input[j]);
                    }
                }
            }
        }
    }
}
