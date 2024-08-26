internal class Program
{
    static void Main()
    {
        List<int> numbers = ReadListOfIntegers();

        var input = string.Empty;

        while ((input = Console.ReadLine()) != "end")
        {
            string[] command = input.Split();

            switch(command[0])
            {
                case "Add":
                    numbers.Add(int.Parse(command[1]));
                    break;
                case "Remove":
                    numbers.Remove(int.Parse(command[1]));
                    break;
                case "RemoveAt":
                    numbers.RemoveAt(int.Parse(command[1]));
                    break;
                case "Insert":
                    numbers.Insert(int.Parse(command[2]), int.Parse(command[1]));
                    break;
            }
        }

        PrintListOfIntegers(numbers);
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
}