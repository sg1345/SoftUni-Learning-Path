﻿namespace _02.KnightsOfHonor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Action<string> print = name => Console.WriteLine($"Sir {name}");

            foreach (string name in names)
            {
                print(name);
            }
        }
    }
}
