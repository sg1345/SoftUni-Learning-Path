internal class Program
{
    static void Main()
    {
        var start = int.Parse(Console.ReadLine());
        var end = int.Parse(Console.ReadLine());

        var sum = 0;

        for (var number = start; number <= end; number++) 
        {
            Console.Write($"{number} ");
            sum += number;
        }
        Console.WriteLine();
        Console.WriteLine($"Sum: {sum}");
    }
}