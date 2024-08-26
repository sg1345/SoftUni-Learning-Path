internal class Program
{
    static void Main()
    {
        var number = int.Parse(Console.ReadLine());

        List<string> list = new List<string>();
        
        for(int i  = 0; i < number; i++) 
        {
            list.Add(Console.ReadLine());
        }
        
        list.Sort();

        for (int i = 0; i < list.Count; i++)
        {
            Console.WriteLine($"{i + 1}.{list[i]}");
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
}