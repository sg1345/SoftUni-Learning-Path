
internal class Program
{
    static void Main()
    {
        var firstNumber = int.Parse(Console.ReadLine());
        var @operator = Console.ReadLine();
        var secondNumber = int.Parse(Console.ReadLine());

        var result = Calculate(firstNumber, @operator, secondNumber);
        Console.WriteLine(result);
    }

    static double Calculate(int firstNumber, string @operator, int secondNumber)
    {
        double result = 0;

        switch (@operator)
        {
            case "+":
                result = firstNumber + secondNumber;
                break;
            case "-":
                result = firstNumber - secondNumber;
                break;
            case "*":
                result = firstNumber * secondNumber;
                break;
            default:
                result = (double)firstNumber / secondNumber;
                break;
        }

        return result;
    }
}