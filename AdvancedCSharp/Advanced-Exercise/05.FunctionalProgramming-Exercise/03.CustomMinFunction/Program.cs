namespace _03.CustomMinFunction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int minNumber = int.MaxValue;

            foreach (int number in numbers)
            {
                Func<int, int> comparer = MinNumber(minNumber);
                minNumber = comparer(number);
            }

            Console.WriteLine(minNumber);
        }

        static Func<int, int> MinNumber(int minNumber)
        {
            return number => number < minNumber ? number : minNumber;
        }
    }
}
