internal class Program
{
    static void Main()
    {
        List<int> numbers = ReadListOfIntegers();
            
        var isChanged = false;

        var input = string.Empty;

        while ((input = Console.ReadLine()) != "end")
        {
            var command = input.Split();


            switch (command[0])
            {
                case "Add":

                    numbers.Add(int.Parse(command[1]));
                    isChanged = true;
                    break;

                case "Remove":

                    numbers.Remove(int.Parse(command[1]));
                    isChanged = true;
                    break;

                case "RemoveAt":

                    numbers.RemoveAt(int.Parse(command[1]));
                    isChanged = true;
                    break;

                case "Insert":

                    numbers.Insert(int.Parse(command[2]), int.Parse(command[1]));
                    isChanged = true;
                    break;

                case "Contains":

                    if (numbers.Contains(int.Parse(command[1])))
                    {
                        Console.WriteLine("Yes");
                    }
                    else
                    {
                        Console.WriteLine("No such number");
                    }
                    break;

                case "PrintEven":

                    PrintEvenNumbers(numbers);
                    break;

                case "PrintOdd":

                    PrintOddNumbers(numbers);
                    break;

                case "GetSum":

                    PrintSumOfList(numbers);
                    break;

                case "Filter":

                    var number = int.Parse(command[2]);
                    PrintFilteredList(numbers, command[1], number);
                    break;
            }

        }
        
        if (isChanged)
            {
                PrintListOfIntegers(numbers);
            }
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

    static void PrintOddNumbers(List<int> numbers)
    {
        var oddNumbers = numbers.Where(number => number % 2 == 1).ToArray();

        Console.WriteLine(string.Join(" ", oddNumbers));
    }
    static void PrintEvenNumbers(List<int> numbers)
    {
        var evenNumbers = numbers.Where(number => number % 2 == 0).ToArray();

        Console.WriteLine(string.Join(" ",evenNumbers));
    }
    static void PrintSumOfList(List<int> numbers)
    {
        int sum = numbers.Sum();

        Console.WriteLine(sum);
    }
    static void PrintFilteredList(List<int> numbers, string condition, int filter)
    {

        if (condition == "<")
        {
            var array = numbers.Where(number => number < filter).ToArray();

            PrintArrayOfIntegers(array);
        }
        else if (condition == ">")
        {
            var array = numbers.Where(number => number > filter).ToArray();

            PrintArrayOfIntegers(array);
        }
        else if (condition == "<=")
        {
            var array = numbers.Where(number => number <= filter).ToArray();

            PrintArrayOfIntegers(array);
        }
        else //conditioon == ">="
        {
            var array = numbers.Where(number => number >= filter).ToArray();

            PrintArrayOfIntegers(array);
        }
    }
}