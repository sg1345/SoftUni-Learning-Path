internal class Program
{
    static void Main()
    {
        var number = int.Parse(Console.ReadLine());

        PrintTopIntegers(number);
    }

    static void PrintTopIntegers(int number)
    {
        for (int i = 0; i < number; i++)
        {
            if(SumOfDigitsDivisibleByEight(i) && HoldsOddDigit(i))
            {
                Console.WriteLine(i);
            }
        }
    }

    static bool HoldsOddDigit(int number)
    {
        var isTrue = false;

        int[] array = ItegerToArray(number);
       
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] % 2 == 1)
            {
                isTrue = true;
                break;
            }
        }

        return isTrue;
    }

    static bool SumOfDigitsDivisibleByEight(int number)
    {
        var isTrue = false;

        int[] array = ItegerToArray(number);

        var sum = 0;

        for(int i = 0; i < array.Length; i++)
        {
            sum += array[i];
        }

        isTrue = (sum % 8 == 0);

        return isTrue;
    }

    static int[] ItegerToArray(int number)
    {
        var stringNumber = number.ToString();
        int[] array = new int[stringNumber.Length];

        for (int i = 0; i < stringNumber.Length; i++)
        {
            array[i] = stringNumber[i];
        }
        return array;
    }
}
