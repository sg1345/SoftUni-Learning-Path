/*
 
20 30 40 50 => 30 40 50 20 10 => 40 50 20 10 30 20 => 50 20 10 30 20 40 30 => 20 10 30 20 40 30 50 40
10 20 30 40 => 20 30 40       => 30 40             => 40                   =>

*/
internal class Program
{
    static void Main()
    {
        List<int> firstPlayer = ReadListOfIntegers();
        List<int> secondPlayer = ReadListOfIntegers();

        while (firstPlayer.Count != 0 && secondPlayer.Count != 0)
        {
            if (firstPlayer[0] > secondPlayer[0])
            {
                firstPlayer.Add(firstPlayer[0]);
                firstPlayer.Add(secondPlayer[0]);

                firstPlayer.Remove(firstPlayer[0]);
                secondPlayer.Remove(secondPlayer[0]);

            }
            else if (firstPlayer[0] < secondPlayer[0])
            {
                secondPlayer.Add(secondPlayer[0]);
                secondPlayer.Add(firstPlayer[0]);

                secondPlayer.Remove(secondPlayer[0]);
                firstPlayer.Remove(firstPlayer[0]);
            }
            else // firstPlayer[0] == secondPlayer[0]
            {
                secondPlayer.Remove(secondPlayer[0]);
                firstPlayer.Remove(firstPlayer[0]);
            }
        }

        var winning = string.Empty;
        var sum = 0;

        if (firstPlayer.Count == 0)
        {
            winning = "Second";
            sum = secondPlayer.Sum();
        }
        else
        {
            winning = "First";
            sum = firstPlayer.Sum();
        }

        Console.WriteLine($"{winning} player wins! Sum: {sum}");
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