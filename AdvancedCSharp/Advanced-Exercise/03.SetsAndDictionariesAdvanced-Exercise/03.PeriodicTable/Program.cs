internal class Program
{
    static void Main()
    {
        int length = int.Parse(Console.ReadLine());

        HashSet<string> periodicTable = new HashSet<string>();

        for (int i = 0; i < length; i++)
        {
            string[] elements = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            foreach (string element in elements)
            {
                periodicTable.Add(element);
            }
        }

        Console.WriteLine(string.Join(" ", periodicTable.OrderBy(x => x).ToArray()));

    }
}