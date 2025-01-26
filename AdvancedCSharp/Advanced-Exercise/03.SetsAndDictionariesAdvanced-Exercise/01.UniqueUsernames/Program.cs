internal class Program
{
    static void Main()
    {
        int length = int.Parse(Console.ReadLine());

        HashSet<string> names = new();

        for (int i = 0; i < length; i++)
        {
            string name = Console.ReadLine();

            names.Add(name);
        }

        foreach (string name in names)
        {
            Console.WriteLine(name);
        }
    }
}