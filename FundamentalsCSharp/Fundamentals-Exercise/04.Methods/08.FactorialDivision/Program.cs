
using System.Numerics;

internal class Program
{
    static void Main()
    {
        var firstNumber = int.Parse(Console.ReadLine());
        var secondNumber = int.Parse(Console.ReadLine());

        var factorialFirstNumber = Factorial(firstNumber);
        var factorialSecondNumber = Factorial(secondNumber);

        var result = factorialFirstNumber / factorialSecondNumber;

        Console.WriteLine($"{result:f2}");
    }

    static decimal Factorial(int number)
    {
        decimal factorial = 1;
        for (int i = number; i >= 1; i--)
        {
            factorial *= i;    
        }

        return factorial;
    }
}
