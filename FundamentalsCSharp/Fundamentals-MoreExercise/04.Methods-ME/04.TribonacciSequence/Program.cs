using System.Net.Http.Headers;

internal class Program
{
    static void Main()
    {
        int length = int.Parse(Console.ReadLine());

        int[] tribonacciArray = new int[length];

        for (int i = 0; i < tribonacciArray.Length; i++)
        {
            if (i == 0 || i == 1)
            {
                tribonacciArray[i] = 1;
                continue;
            }

            if (i == 2)
            {
                tribonacciArray[i] = 2;
                continue;
            }

            tribonacciArray[i] = sumTribonacci(tribonacciArray, i);
        }

        Console.WriteLine(string.Join(' ',tribonacciArray));
    }

    private static int sumTribonacci(int[] tribonacciArray, int i)
    {
        return tribonacciArray[i - 1] + tribonacciArray[i - 2] + tribonacciArray[i - 3];
    }
}
