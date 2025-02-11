namespace _08.Threeuple
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] nameAddress = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string[] beers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string[] bank = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Threeuple<string, string, string> first = new
                (
                $"{nameAddress[0]} {nameAddress[1]}",
                nameAddress[2], string.Join(' ', nameAddress[3..])
                );

            Threeuple<string, int, bool> second = new
                (beers[0], int.Parse(beers[1]), beers[2] == "drunk");

            Threeuple<string, double, string> third = new(
                bank[0], double.Parse(bank[1]), bank[2]);


            Console.WriteLine(first);
            Console.WriteLine(second);
            Console.WriteLine(third);
        }
    }
}
