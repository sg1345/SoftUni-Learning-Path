
using System.Collections.Generic;

internal class Program
{
    static void Main()
    {
        var numbers = ReadListOfDoubles();

        for(int i = 0; i < numbers.Count - 1; i++)
        {
            double firstNumber = numbers[i];
            double secondNumber = numbers[i + 1];

            if(firstNumber == secondNumber)
            {
                numbers[i] = firstNumber + secondNumber;
                numbers.Remove(secondNumber);
                i = -1;
            }
        }

        PrintListOfDoubles(numbers);
    }


    static List<int> ReadListOfIntegers(string separator = " ")
    {
        return Console.ReadLine().Split(separator).Select(int.Parse).ToList();
    }
    static List<double> ReadListOfDoubles(string separator = " ")
    {
        return Console.ReadLine().Split(separator).Select(double.Parse).ToList();
    }
    static List<String> ReadListOfStrings (string separator = " ")
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
}