﻿
int floor = int.Parse(Console.ReadLine());
int rooms = int.Parse(Console.ReadLine());

for (int i = floor; i >= 1; i--)
{
    Console.WriteLine();
    for (int j = 0; j < rooms; j++)
    {
        if (i == floor)
        {
        Console.Write($" L{i}{j}");
        }
        else if (i%2 == 0)
        {
        Console.Write($" O{i}{j}");
        }
        else
        {
            Console.Write($" A{i}{j}");
        }
    }

}