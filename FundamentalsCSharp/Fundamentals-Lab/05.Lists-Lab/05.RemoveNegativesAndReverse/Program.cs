internal class Program
{
    static void Main()
    {
        List<int> list = ReadListOfIntegers();

        for (int i = 0; i < list.Count; i++)
        {
            if (list[i] < 0)
            {
                list.RemoveAt(i);

                i = -1;
            }
        }

        if(list.Count == 0)
        {
            Console.WriteLine("empty");
            return;
        }

        list.Reverse();

        PrintListOfIntegers(list);
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