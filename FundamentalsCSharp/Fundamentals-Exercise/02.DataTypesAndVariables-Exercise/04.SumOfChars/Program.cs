internal class Program
{
    static void Main()
    {

       var charCount = int.Parse(Console.ReadLine());

        var totalSum = 0;

        for (int i = 0; i < charCount; i++)
        {
            var character = char.Parse(Console.ReadLine());

            totalSum += character;
        }
        Console.WriteLine($"The sum equals: {totalSum}");
    }
}