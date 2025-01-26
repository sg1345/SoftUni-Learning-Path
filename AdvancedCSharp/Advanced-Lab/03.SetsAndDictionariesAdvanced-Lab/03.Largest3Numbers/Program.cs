using System.ComponentModel.DataAnnotations;

internal class Program
{
    static void Main()
    {
        List<int> numbers = Console.ReadLine()
            .Split(' ',StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToList();

        int[] sorted = numbers.OrderByDescending(number => number).ToArray();

        int length = 3;
        if (sorted.Length < 3)
        {
            length = sorted.Length;
        }


        for (int i = 0; i < length; i++)
        {
            Console.Write($"{sorted[i]} ");
        }
    }
}
