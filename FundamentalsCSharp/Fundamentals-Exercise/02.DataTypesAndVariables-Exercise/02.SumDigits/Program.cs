internal class Program
{
    static void Main()
    {
        var number = Console.ReadLine();

        var result = 0;

        for (int i = 0; i < number.Length; i++)
        {
            result += number[i] - 48; // ASCII table
        }

        Console.WriteLine(result);
    }
}