using System.ComponentModel;

internal class Program
{
    static void Main()
    {
        List<int> firstList = ReadListOfIntegers();
        List<int> secondList = ReadListOfIntegers();

        var biggerLength = 0;
        var smallerLength = 0;
        bool isFirstBigger = false;

        if(firstList.Count > secondList.Count)
        {
            biggerLength = firstList.Count;
            smallerLength = secondList.Count;
            isFirstBigger = true;
        }
        else
        {
            biggerLength = secondList.Count;
            smallerLength = firstList.Count;
        }

        List<int> result = new List<int>();

        for( int i = 0; i < smallerLength; i++ )
        {
            result.Add(firstList[i]);
            result.Add(secondList[i]);
        }

        for(int i = smallerLength; i < biggerLength; i++)
        {
            if (isFirstBigger)
            {
                result.Add(firstList[i]);
            }
            else 
            {
                result.Add(secondList[i]);
            }
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