namespace _01.SortEvenNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //    int[] evenNumbers = Console.ReadLine()
            //.Split(", ", StringSplitOptions.RemoveEmptyEntries)
            //.Select(int.Parse)
            //.Where(x => x % 2 == 0)
            //.OrderBy(x => x)
            //.ToArray();

            //    Console.WriteLine(string.Join(", ", evenNumbers));

            Console.WriteLine
            (
                string.Join
                (
                    ", ",
                    Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(number => int.Parse(number))
                    .Where(number => number % 2 == 0)
                    .OrderBy(number => number)
                    .ToArray()
                )
            );
        }
    }
}
