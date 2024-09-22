internal class Program
{
    static void Main()
    {
        decimal firstNumber = decimal.Parse(Console.ReadLine());
        decimal secondNumber = decimal.Parse(Console.ReadLine());

        decimal eps = 0.000001m;
        decimal difference = Math.Abs(firstNumber - secondNumber);

        if (difference >= eps)
        {
            Console.WriteLine("False");
        }
        else
        {
            Console.WriteLine("True");
        }
    }
}