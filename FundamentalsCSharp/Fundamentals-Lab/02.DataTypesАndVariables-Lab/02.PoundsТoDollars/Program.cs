internal class Program
{
    static void Main()
    {
        var GBP = decimal.Parse(Console.ReadLine());

        var USD = GBP * 1.31m;

        Console.WriteLine($"{USD:f3}");
    }
}
