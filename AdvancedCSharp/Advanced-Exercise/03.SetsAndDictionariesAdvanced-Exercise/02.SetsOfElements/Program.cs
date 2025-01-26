internal class Program
{
    static void Main()
    {
        int[] length = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        HashSet<string> firstSet = new();
        HashSet<string> secondSet = new();

        for (int i = 0; i < length[0]; i++)
        {
            firstSet.Add(Console.ReadLine());
        }

        for (int i = 0; i < length[1]; i++)
        {
            secondSet.Add(Console.ReadLine());
        }

        HashSet<string> pairOfElements = new();

        foreach(var element in firstSet)
        {
            if (secondSet.Contains(element))
            {
                pairOfElements.Add(element);
            }
        }

        Console.WriteLine(string.Join(' ',pairOfElements));
    }
}