﻿
int number = int.Parse(Console.ReadLine());

int count = 0;

for (int i = 1; i <= number; i++)
{
    for (int j = 1; j <= i; j++)
    {
        count++;
        if (count <= number)
        {
        Console.Write($"{count} ");
        }
    }
        Console.WriteLine();
}