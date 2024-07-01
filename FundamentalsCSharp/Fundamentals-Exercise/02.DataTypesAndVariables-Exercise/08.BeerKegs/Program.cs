internal class Program
{
    static void Main()
    {
        var kegCount = byte.Parse(Console.ReadLine());

        var biggestKeg = double.MinValue;
        var biggestKegName = " ";

        for (byte i = 0; i < kegCount; i++)
        {
            var name = Console.ReadLine();
            var kegRadius = double.Parse(Console.ReadLine());
            var kegHeight = int.Parse(Console.ReadLine());

            var volume = Math.PI * Math.Pow(kegRadius, 2) * kegHeight;

            if (volume > biggestKeg)
            {
                biggestKeg = volume;
                biggestKegName = name;
            }
        }

        Console.WriteLine(biggestKegName);
    }
}