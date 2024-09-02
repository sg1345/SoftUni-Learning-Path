internal class Program
{
    static void Main()
    {
        List<string> guestList = new List<string>();

        var count = int.Parse(Console.ReadLine());

        for (int i = 0; i < count; i++)
        {
            string[] input = ReadArrayOfStrings();

            var name = input[0];

            if (guestList.Contains(name))
            {
                if (IsGoing(input[2])) // input == "going"
                {
                    Console.WriteLine($"{name} is already in the list!");
                }
                else // input == "not"
                {
                    guestList.Remove(name);
                }
            }
            else // guestList does not contains the name
            {
                if (IsGoing(input[2])) //input == "going"
                {
                    guestList.Add(name);
                }
                else // input == "not"
                {
                    Console.WriteLine($"{name} is not in the list!");
                }
            }
        }

        PrintListOfStrings(guestList,"\n");
    }

    static bool IsGoing(string input)
    {
        return input == "going!";
    }

    static string[] ReadArrayOfStrings(string separator = " ")
    {
        return Console.ReadLine().Split(separator);
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