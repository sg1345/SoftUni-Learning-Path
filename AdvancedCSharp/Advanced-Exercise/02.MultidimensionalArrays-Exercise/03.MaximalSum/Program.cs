using System.Runtime.CompilerServices;

internal class Program
{
    static void Main()
    {
        int[] Length = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        int[,] matrix = new int[Length[0], Length[1]];

        for (int i = 0; i < Length[0]; i++)
        {
            int[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            for (int j = 0; j < Length[1]; j++)
            {
                matrix[i, j] = input[j];
            }
        }

        int sum = 0;
        int maximalSum = int.MinValue;
        int indexCol = 0;
        int indexRow = 0;
        for (int i = 0; i < matrix.GetLength(0) - 2; i++)
        {
            for (int j = 0; j < matrix.GetLength(1) - 2; j++)
            {
                sum = matrix[i + 0, j] + matrix[i + 0, j + 1] + matrix[i + 0, j + 2]
                    + matrix[i + 1, j] + matrix[i + 1, j + 1] + matrix[i + 1, j + 2]
                    + matrix[i + 2, j] + matrix[i + 2, j + 1] + matrix[i + 2, j + 2];

                if (sum > maximalSum)
                {
                    maximalSum = sum;
                    indexCol = i;
                    indexRow = j;
                }
            }
        }
        Console.WriteLine($"Sum = {maximalSum}");

        for (int i = indexCol; i <= indexCol + 2; i++)
        {
            for (int j = indexRow; j <= indexRow + 2; j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}