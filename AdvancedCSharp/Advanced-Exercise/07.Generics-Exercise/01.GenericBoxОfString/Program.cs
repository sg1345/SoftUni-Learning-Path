﻿namespace _01.GenericBoxОfString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Box<string> box = new(Console.ReadLine());

                Console.WriteLine(box);
            }
        }
    }
}
