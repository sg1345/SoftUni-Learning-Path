﻿using System.Numerics;

internal class Program
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());

        BigInteger bigFactorial = 1;

        for (int i = 2; i <= number; i++)
        {
            bigFactorial *= i;
        }

        Console.WriteLine(bigFactorial);
    }
}