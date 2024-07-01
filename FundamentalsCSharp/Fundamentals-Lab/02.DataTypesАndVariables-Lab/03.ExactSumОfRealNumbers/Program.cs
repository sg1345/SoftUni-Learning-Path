internal class Program
{
    static void Main()
    {
        var countNumbers = int.Parse(Console.ReadLine());

        var sum = 0.0m;

        for (int i = 1; i <= countNumbers; i++)
        {
            var number = decimal.Parse(Console.ReadLine());
            
            sum += number;
        }

        var copySum = (long)sum;

        if (copySum == sum)
        {
            Console.WriteLine($"{copySum}");
        }
        else
        {
            Console.WriteLine(sum);
        }

    }

}
