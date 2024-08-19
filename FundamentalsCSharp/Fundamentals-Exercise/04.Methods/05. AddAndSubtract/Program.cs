
internal class Program
{
    static void Main()
    {
        var firstNumber = int.Parse(Console.ReadLine());
        var secondNumber = int.Parse(Console.ReadLine());
        var thirdNumber = int.Parse(Console.ReadLine());

        var sum = SumTwoNumbers(firstNumber, secondNumber);
        var finalResult = SubtractTwoNumbers(sum, thirdNumber);

        Console.WriteLine(finalResult);
    }

    static int SubtractTwoNumbers(int sum, int thirdNumber)
    {
        var subtract = sum - thirdNumber;

        return subtract;
    }

    static int SumTwoNumbers(int firstNumber, int secondNumber)
    {
        var sum = firstNumber + secondNumber;

        return sum;
    }
}
