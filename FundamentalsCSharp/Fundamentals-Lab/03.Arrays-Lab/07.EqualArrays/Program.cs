using System;

internal class Program
{
    static void Main()
    {
        int[] array = Console.ReadLine()
                      .Split()
                      .Select(int.Parse)
                      .ToArray();

        int[] array2 = Console.ReadLine()
                     .Split()
                     .Select(int.Parse)
                     .ToArray();

        int sum = 0;

        for (int i = 0; i < array.Length; i++)
        {
            if (array2[i] == array[i])
            {
                sum += array[i];
            }
            else
            {
                Console.WriteLine($"Arrays are not identical. Found difference at {i} index");
                return;
            }
        }

        Console.WriteLine($"Arrays are identical. Sum: {sum}");
    }
}