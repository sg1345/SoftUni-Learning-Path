internal class Program
{
    static void Main(string[] args)
    {
        int[] borders = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(number => int.Parse(number))
            .ToArray();

        string condition = Console.ReadLine();

        Predicate<int> filter;
        if (condition == "even")
        {
            filter = number => number % 2 == 0;
        }
        else if (condition == "odd")
        {
            filter = number => number % 2 == 1;
        }
        else
        {
            filter = x => false;
        }

        List<int> list = new List<int>();
        for (int i = borders[0]; i <= borders[1]; i++)
        {
            if (filter(i))
            {
                list.Add(i);
            }
        }

        Console.WriteLine(string.Join(' ', list));
    }
}