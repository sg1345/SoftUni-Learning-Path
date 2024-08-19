

internal class Program
{
    static void Main()
    {
        var number = int.Parse(Console.ReadLine());

        PrintSquareMatrix(number);
    }

    static void PrintSquareMatrix(int number)
    {
        for (int i = 0; i < number; i++)
        {
            for(int j = 0; j < number; j++)
            {
                Console.Write($"{number} ");
            }

            Console.WriteLine();
        }
    }
}
