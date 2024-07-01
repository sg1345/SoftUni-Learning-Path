internal class Program
{
    static void Main()
    {
        var centuries = int.Parse(Console.ReadLine());

        var years = centuries * 100;
        var days = (int)(years * 365.2422);
        var hours = days * 24;
        var minutes = (long)(hours * 60);

        Console.WriteLine($"{centuries} centuries = {years} years = {days} days = {hours} hours = {minutes} minutes");

    }
}
