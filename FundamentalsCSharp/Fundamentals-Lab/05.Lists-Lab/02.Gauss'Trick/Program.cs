internal class Program
{
    static void Main()
    {
        List<int> numbers = ReadListOfIntegers();
        
        List<int> result = new List<int>();

        for (int i = 0; i < numbers.Count / 2; i++) // 0 1 2 3 4
        {
            result.Add(numbers[i] + numbers[numbers.Count - i - 1]);            
        }

        if( numbers.Count % 2 == 1 )
        {
            result.Add(numbers[numbers.Count/2]);
        }

        PrintListOfIntegers(result);
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