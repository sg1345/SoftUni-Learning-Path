﻿internal class Program
{
    static void Main()
    {
        List<string> list = ReadListOfStrings("|");

        List<string> output = new List<string>();

        for (int i = list.Count - 1; i >= 0; i--)
        {           
            var currentArray = list[i].Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            output.AddRange(currentArray);
        }

        PrintListOfStrings(output);
    }

    static List<int> ReadListOfIntegers(string separator = " ")
    {
        return Console.ReadLine().Split(separator).Select(int.Parse).ToList();
    }
    static List<double> ReadListOfDoubles(string separator = " ")
    {
        return Console.ReadLine().Split(separator).Select(double.Parse).ToList();
    }
    static List<String> ReadListOfStrings(string separator = " ")
    {
        return Console.ReadLine().Split(separator).ToList();
    }

    static void PrintListOfIntegers(List<int> listInput, string separator = " ")
    {
        Console.WriteLine(string.Join(separator, listInput));
    }
    static void PrintListOfDoubles(List<double> listInput, string separator = " ")
    {
        Console.WriteLine(string.Join(separator, listInput));
    }
    static void PrintListOfStrings(List<string> listInput, string separator = " ")
    {
        Console.WriteLine(string.Join(separator, listInput));
    }
    static void PrintArrayOfIntegers(int[] array, string separator = " ")
    {
        Console.WriteLine(string.Join(separator, array));
    }
}