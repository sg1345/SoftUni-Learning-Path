using System.Security.Cryptography.X509Certificates;

internal class Program
{
    static void Main()
    {
        int[] numbers = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();

        string command = string.Empty;

        while ((command = Console.ReadLine()) != "end")
        {
            string[] input = command.Split();

            switch (input[0])
            {
                case "swap":
                    int firstIndex = int.Parse(input[1]);
                    int secondIndex = int.Parse(input[2]);

                    ArrayIndexSwap(numbers, firstIndex , secondIndex);
                    break;
                case "multiply":
                    int multipied = int.Parse(input[1]);
                    int multiplier = int.Parse(input[2]);

                    ArrayNumberMultiplierIndexByIndex(numbers, multipied , multiplier);
                    break;
                case "decrease":
                    ArrayNumbersDecreasedByOne(numbers);
                    break;
            }
        }

        Console.WriteLine(string.Join(", ",numbers));
    }

    static void ArrayNumbersDecreasedByOne(int[] numbers)
    {
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] -= 1;
        }
    }

    static void ArrayNumberMultiplierIndexByIndex(int[] array, int multipied, int multiplier)
    {
        array[multipied] *= array[multiplier];
    }

    static void ArrayIndexSwap(int[] array, int firstIndex, int secondIndex)
    {
        int firstNumber = array[firstIndex];
        int secondNumber = array[secondIndex];

        array[firstIndex] = secondNumber;
        array[secondIndex] = firstNumber;
    }
}