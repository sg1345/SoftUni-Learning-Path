using System.Xml;

internal class Program
{
    static void Main()
    {
        List<int> firstList = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToList();

        List<int> secondList = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToList();

        List<int> mixedList = new();

        int indexFirstList = 0;
        while (firstList.Count != 0 || secondList.Count != 0)
        {
            if (firstList.Count == 0 || secondList.Count == 0)
            {
                break;
            }

            mixedList.Add(firstList[0]);
            mixedList.Add(secondList[secondList.Count - 1]);

            firstList.RemoveAt(0);
            secondList.RemoveAt(secondList.Count - 1);

        }

        int leftBorder = 0;
        int rightBorder = 0;

        if (firstList.Count == 2)
        {
            leftBorder = firstList[0] > firstList[1] ? firstList[1] : firstList[0];
            rightBorder = firstList[1] > firstList[0] ? firstList[1] : firstList[0];
        }
        else
        {
            leftBorder = secondList[0] > secondList[1] ? secondList[1] : secondList[0];
            rightBorder = secondList[1] > secondList[0] ? secondList[1] : secondList[0];
        }

        List<int> result = mixedList.Where(x => x > leftBorder && x < rightBorder).ToList();
        result.Sort();

        Console.WriteLine(string.Join(' ', result));
    }
}