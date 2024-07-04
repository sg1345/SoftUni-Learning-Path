internal class Program
{
    static void Main()
    {
        double[] array = Console.ReadLine()
                                .Split()
                                .Select(double.Parse)
                                .ToArray();

        int roundedNumber = 0;

        for (int i = 0; i < array.Length; i++)
        {
            roundedNumber = (int)Math.Round(array[i], MidpointRounding.AwayFromZero);
            Console.WriteLine($"{array[i]} => {roundedNumber}");
        }
    }
}