namespace _01.MonsterExtermination
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> monsters = new Queue<int>();
            Stack<int> soldiers = new Stack<int>();

            for (int i = 0; i < 2; i++)
            {
                int[] input = Console.ReadLine()
                    .Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for (int j = 0; j < input.Length; j++)
                {
                    if (i == 0)
                    {
                        monsters.Enqueue(input[j]);
                    }
                    else if (i == 1)
                    {
                        soldiers.Push(input[j]);
                    }
                }
            }

            int killedMonsters = 0;
            while (soldiers.Count > 0 && monsters.Count > 0)
            {
                int defence = monsters.Dequeue();
                int attack = soldiers.Pop();

                if (defence == attack)
                {
                    killedMonsters++;
                    continue;
                }
                else if (defence < attack)
                {
                    killedMonsters++;
                    int remaining = attack - defence;

                    if (soldiers.Count > 0)
                    {
                        int newAttack = soldiers.Pop() + remaining;
                        soldiers.Push(newAttack);
                        continue;
                    }
                    soldiers.Push(remaining);

                }
                else //if(defence < attack)
                {
                    monsters.Enqueue(defence - attack);
                }
            }

            if (monsters.Count == 0)
            {
                Console.WriteLine("All monsters have been killed!");
            }

            if (soldiers.Count == 0)
            {
                Console.WriteLine("The soldier has been defeated.");
            }

            Console.WriteLine($"Total monsters killed: {killedMonsters}");
        }
    }
}