internal class Program
{
    static void Main()
    {
        int endNumber = int.Parse(Console.ReadLine());
        for (int currentNumber = 2; currentNumber <= endNumber; currentNumber++)
        {
            bool isPrime = true;
            for (int i = 2; i < currentNumber; i++)
            {
                if (currentNumber % i == 0)
                {
                    isPrime = false;
                    break;
                }
            }

            Console.WriteLine($"{currentNumber} -> {isPrime.ToString().ToLower()}");
        }

    }
}