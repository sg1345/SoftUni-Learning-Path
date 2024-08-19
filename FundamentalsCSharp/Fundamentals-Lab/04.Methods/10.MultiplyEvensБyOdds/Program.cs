internal class Program
{
    static void Main()
    {
        var input = int.Parse(Console.ReadLine());
        var absNumber = Math.Abs(input);
        
        var length = absNumber.ToString().Length;
        var sumOdd = 0;
        var sumEven = 0;


        for (int i = 1; i <= length; i++)
        {
            var digit = absNumber % 10;

            sumOdd = GetSumOfOddDigits(digit,sumOdd);

            sumEven = GetSumOfEvenDigits(digit, sumEven);
            
            absNumber /=10;
        }

        var result = GetMultipleOfEvenAndOdd(sumOdd, sumEven);

        Console.WriteLine(result);
    }

    static int GetMultipleOfEvenAndOdd(int sumOdd, int sumEven)
    {
        var result = sumEven * sumOdd;
        return result;
    }

    static int GetSumOfOddDigits(int digit, int sumOdd)
    {
        if (digit % 2 == 1)
        {
            sumOdd += digit;
        }

        return sumOdd;
    }

    static int GetSumOfEvenDigits(int digit, int sumEven)
    {
        if (digit % 2 == 0)
        {
            sumEven += digit;
        }

        return sumEven;
    }
}