namespace _04.Froggy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Lake lake = new Lake
                (
                Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray()
                );

            Console.WriteLine(string.Join(", ",lake));
        }
    }
}
