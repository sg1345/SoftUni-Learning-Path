namespace _06._ReverseAndExclude
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ',StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int filterNumber = int.Parse(Console.ReadLine());

            Predicate<int> devisableBySpecialNumber = x => x % filterNumber == 0;

            List<int> list = new List<int>();
            for (int i = numbers.Length - 1; i >= 0; i--)
            {
                if (!devisableBySpecialNumber(numbers[i]))
                {
                    list.Add(numbers[i]);
                }
            }

            Console.WriteLine(string.Join(' ',list));
        }
    }
}
