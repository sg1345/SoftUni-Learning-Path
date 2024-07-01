internal class Program
{
    static void Main()
    {
        var meters = int.Parse(Console.ReadLine());

        var kilometeres = Math.Round(meters/1000.0,2);

        Console.WriteLine($"{kilometeres:f2}");
    }
}
