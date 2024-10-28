

internal class Program
{
    static void Main()
    {
        int numberOne = int.Parse(Console.ReadLine());
        int numberTwo = int.Parse(Console.ReadLine());
        int numberThree = int.Parse(Console.ReadLine());

        if (IsZero(numberOne) ||
           IsZero(numberTwo) ||
           IsZero(numberThree))
        {
            Console.WriteLine("zero");
            return;
        }

        int[] array = { numberOne, numberTwo, numberThree };
        int minusCount = 0;
        foreach (int number in array)
        {
            if (IsNegative(number))
            {
                minusCount++;
            }
        }

        if (minusCount % 2 == 0)
        {
            Console.WriteLine("positive");
            return;
        }

        Console.WriteLine("negative");
    }

    static bool IsZero(int number)
    {
        if (number == 0)
        {
            return true;
        }
        return false;
    }

    static bool IsNegative(int number)
    {
        if (number < 0)
        {
            return true;
        }

        return false;
    }
}

