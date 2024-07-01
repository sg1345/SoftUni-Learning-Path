internal class Program
{
    static void Main()
    {
        var endNumber = int.Parse(Console.ReadLine());

        for (int number = 1; number <= endNumber; number++)
        {
            var copyNum = number;
            var sum = 0;
            while (copyNum > 0)
            {
                sum += copyNum % 10;
                copyNum /= 10;

            }
            bool isSpecial = (sum == 5 || sum == 7 || sum == 11);
            Console.WriteLine($"{number} -> {isSpecial}");
        }
    }
}
