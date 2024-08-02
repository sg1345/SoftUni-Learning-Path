
internal class Program
{
    static void Main()
    {
        var command = Console.ReadLine();

        var firstNumber = double.Parse(Console.ReadLine()); 
        var secondNumber = double.Parse(Console.ReadLine());

       switch (command)
        {
            case "add":
                PrintAdd(firstNumber,secondNumber);
                break;
            case "subtract":
                PrintSubtract(firstNumber, secondNumber);
                break;
            case "multiply":
                PrintMultiply(firstNumber, secondNumber);
                break;
            case "divide":
                PrintDivide(firstNumber, secondNumber);
                break;
        }
    }

    static void PrintDivide(double firstNumber, double secondNumber)
    {
        Console.WriteLine(firstNumber / secondNumber);
    }

    static void PrintMultiply(double firstNumber, double secondNumber)
    {
        Console.WriteLine(firstNumber * secondNumber);
    }

    static void PrintSubtract(double firstNumber, double secondNumber)
    {
        Console.WriteLine(firstNumber - secondNumber);
    }

    static void PrintAdd(double firstNumber, double secondNumber)
    {
        Console.WriteLine(firstNumber + secondNumber);
    }
}