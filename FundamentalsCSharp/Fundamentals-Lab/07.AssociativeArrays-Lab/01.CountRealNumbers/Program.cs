internal class Program
{
    static void Main()
    {
        double[] numbers = Console.ReadLine()
        .Split()
        .Select(double.Parse)
        .ToArray();

        SortedDictionary<double, int> numbersCounter = new();

        foreach (double number in numbers)
        {
            if (numbersCounter.ContainsKey(number))
            {
                numbersCounter[number]++;
                continue;
            }

            numbersCounter[number] = 1;
        }

        foreach (KeyValuePair<double,int> numberCounter in numbersCounter)
        {
            Console.WriteLine($"{numberCounter.Key} -> {numberCounter.Value}");
        }
    }
}