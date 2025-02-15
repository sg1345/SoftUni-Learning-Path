namespace _01.TempleOfDoom
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> tools = new Queue<int>();
            Stack<int> substances = new Stack<int>();
            List<int> challanges = new List<int>();

            for (int i = 0; i < 3; i++)
            {
                int[] input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                if (i == 0)
                {
                    foreach (int x in input)
                    {
                        tools.Enqueue(x);
                    }
                }
                else if (i == 1)
                {
                    foreach (int x in input)
                    {
                        substances.Push(x);
                    }
                }
                else if (i == 2)
                {
                    foreach (var x in input)
                    {
                        challanges.Add(x);
                    }
                }
            }

            while (tools.Count > 0 && substances.Count > 0 && challanges.Count > 0)
            {
                int tool = tools.Dequeue();
                int substance = substances.Pop();

                int solution = tool * substance;
                if (challanges.Any(x => x == solution))
                {
                    //гейско е да слагате еднакви числа и да не мога да ползвам where
                    //challanges = challanges.Where(x => x != solution).ToList();//

                    int index = challanges.FindIndex(x => x == solution);
                    challanges.RemoveAt(index);
                    continue;
                }

                tool += 1;
                tools.Enqueue(tool);

                substance -= 1;

                if (substance > 0)
                {
                    substances.Push(substance);
                }
            }

            if (challanges.Count > 0)
            {
                Console.WriteLine("Harry is lost in the temple. Oblivion awaits him.");
            }
            else //if (challanges.Count == 0)
            {
                Console.WriteLine("Harry found an ostracon, which is dated to the 6th century BCE.");
            }

            if (tools.Count > 0)
            {
                Console.WriteLine($"Tools: {string.Join(", ", tools)}");
            }

            if (substances.Count > 0)
            {
                Console.WriteLine($"Substances: {string.Join(", ", substances)}");
            }

            if (challanges.Count > 0)
            {
                Console.WriteLine($"Challenges: {string.Join(", ", challanges)}");
            }
        }
    }
}
