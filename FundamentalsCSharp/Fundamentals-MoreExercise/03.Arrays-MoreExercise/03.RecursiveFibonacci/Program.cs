/*
0 1 2 3 4 5 6  7  8  9
1 1 2 3 5 8 13 21 34 55
 
 
 
 */

internal class Program
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());

        int[] fibunacciArr = new int[number];
        for (int i = 0; i < number; i++)
        {
            if (i == 0 || i == 1)
            {
                fibunacciArr[i] = 1;
                continue;
            }

            fibunacciArr[i] = fibunacciArr[i - 1] + fibunacciArr[i - 2];
        }

        Console.WriteLine(fibunacciArr[fibunacciArr.Length-1]);
    }
}

