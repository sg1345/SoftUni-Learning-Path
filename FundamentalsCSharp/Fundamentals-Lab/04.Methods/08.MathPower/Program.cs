
internal class Program
{
    static void Main()
    {
        var firstNumber = double.Parse(Console.ReadLine());
        var secondNumber = int.Parse(Console.ReadLine());

        var result = MathPower(firstNumber, secondNumber);

        Console.WriteLine(result);
    }

    static double MathPower(double firstNumber, int secondNumber)
    {
        var result = 1d;
        for (int i = 1; i <= secondNumber; i++)
        {
            result *= firstNumber;
        }
        return result;
    }
}