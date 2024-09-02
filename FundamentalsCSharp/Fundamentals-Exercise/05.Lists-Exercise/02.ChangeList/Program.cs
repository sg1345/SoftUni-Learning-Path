internal class Program
{
    static void Main()
    {
        List<int> list = ReadListOfIntegers();

        var input = string.Empty;
        while ((input = Console.ReadLine()) != "end")
        {
            var command = input.Split();

            switch (command[0])
            {
                case "Delete":

                    var element = int.Parse(command[1]);

                    list.RemoveAll(number => number == element);
                    break;
                case "Insert":

                    element = int.Parse(command[1]);
                    var position = int.Parse(command[2]);

                    list.Insert(position, element);
                    break;
            }
        }

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
    static void PrintArrayOfIntegers(int[] array, string separator = " ")
    {
        Console.WriteLine(string.Join(separator, array));
    }
}