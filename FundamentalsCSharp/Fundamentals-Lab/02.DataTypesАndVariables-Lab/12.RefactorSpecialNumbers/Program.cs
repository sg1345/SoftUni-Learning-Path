internal class Program
{
    static void Main()
    {
        int endNumber = int.Parse(Console.ReadLine());

        for (int number = 1; number <= endNumber; number++)
        {
            int sum = 0;
            int numberCopy = number;
            while (number > 0)
            {
                sum += number % 10;
                number = number / 10;
            }
            bool isSpecialNumber = (sum == 5) || (sum == 7) || (sum == 11);
            Console.WriteLine($"{numberCopy} -> {isSpecialNumber}");
            sum = 0;
            number = numberCopy;
        }

    }
}
