namespace _03.CountUppercaseWords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<string, bool> onlyUpperCase = word => word[0] == word.ToUpper()[0];

            string[] words = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Where(onlyUpperCase)
                .ToArray();

            Console.WriteLine(string.Join("\n", words));

        }
    }
}
