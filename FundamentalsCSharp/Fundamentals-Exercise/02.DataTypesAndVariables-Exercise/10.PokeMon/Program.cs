internal class Program
{
    static void Main()
    {
        var power = int.Parse(Console.ReadLine());
        var range = int.Parse(Console.ReadLine());
        var divider = int.Parse(Console.ReadLine());

        var counter = 0;
        var percengate = power * 0.5;

        while (power >= range)
        {
            power -= range;
            
            if (percengate == power && divider != 0)
            {
                power /= divider;
            }
            counter++;
        }

        Console.WriteLine(power);
        Console.WriteLine(counter);
    }
}