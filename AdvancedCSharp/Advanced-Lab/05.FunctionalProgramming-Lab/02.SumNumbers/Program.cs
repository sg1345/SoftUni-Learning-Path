namespace _02.SumNumbers
{
    internal class Program
    {
        delegate int ArrayInfo(int[] numbers);
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(number => int.Parse(number))
                .ToArray();

            ArrayInfo sumArray = SumArray;
            ArrayInfo countArrayIndexes = ArrayCounter;

            int sum = sumArray(numbers);
            int count = countArrayIndexes(numbers);

            Console.WriteLine(count);
            Console.WriteLine(sum);
        }

        public static int SumArray(int[] numbers)
        {
            return numbers.Sum(number => number);
        }
        public static int ArrayCounter(int[] numbers)
        {
            return numbers.Count();
        }
    }
}