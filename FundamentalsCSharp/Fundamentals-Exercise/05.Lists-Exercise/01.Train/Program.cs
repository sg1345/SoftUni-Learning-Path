using System.Data;

internal class Program
{
    static void Main()
    {
        List<int> train = ReadListOfIntegers();
        var wagonCapacity = int.Parse(Console.ReadLine());

        var input = string.Empty;
        
        while ((input = Console.ReadLine())!= "end")
        {
            var command = input.Split().ToArray();
            switch (command[0])
            {
                case "Add":
                    train.Add(int.Parse(command[1]));
                    break;
                default:

                    var passangers = int.Parse(command[0]);

                    PassengerNavigationControl(passangers,wagonCapacity,train);
                    break;
            }
        }

        PrintListOfIntegers(train);
    }

    static void PassengerNavigationControl(int people, int wagonCapacity, List<int> train)
    {
        for (int i = 0; i < train.Count; i++)
        {
            if (people + train[i] <= wagonCapacity)
            {
                train[i] += people;
                break;
            }
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

}