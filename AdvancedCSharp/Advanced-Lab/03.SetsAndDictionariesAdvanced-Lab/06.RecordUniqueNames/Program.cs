internal class Program
{
    static void Main()
    {
        int length = int.Parse(Console.ReadLine());
        HashSet<string> uniqueNames = new();

        for (int i = 0; i < length; i++)
        {
            uniqueNames.Add(Console.ReadLine());
        }

        foreach (string name in uniqueNames)
        {
            Console.WriteLine(name);
        }
    }
}