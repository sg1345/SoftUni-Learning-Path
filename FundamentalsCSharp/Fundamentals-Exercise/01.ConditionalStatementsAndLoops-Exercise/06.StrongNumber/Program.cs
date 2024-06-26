using System.Diagnostics.CodeAnalysis;

internal class Program
{
    static void Main()
    {
        var input = Console.ReadLine();
        var number = int.Parse(input);
        var numberCopy = number;
        var sum = 0;

        for (int i = 0; i < input.Length; i++) 
        {
            var digit = numberCopy % 10;
            numberCopy /= 10;
            var facturial = 1;
            for (int j = 1; j <= digit; j++)
            {
                facturial *= j;
            }
            sum += facturial;
        }

        if (number == sum)
        {
            Console.WriteLine("yes");
        }
        else
        {
            Console.WriteLine("no");
        }
    }
}