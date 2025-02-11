namespace _07.Tuple
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] nameAddress = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string[] beers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Tuple<string, string> first = new
                (
                $"{nameAddress[0]} {nameAddress[1]}", string.Join(' ', nameAddress[2..])
                );

            Tuple<string, int> second = new(beers[0], int.Parse(beers[1]));

            Tuple<int, double> third = new(
                int.Parse(numbers[0]), double.Parse(numbers[1]));


            Console.WriteLine(first);
            Console.WriteLine(second);
            Console.WriteLine(third);
        }
    }
}
