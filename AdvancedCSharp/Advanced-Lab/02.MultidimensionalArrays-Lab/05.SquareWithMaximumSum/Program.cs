internal class Program
{
    private static int j;

    static void Main()
    {
        int[] rowsCols = Console.ReadLine()
            .Split(", ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        int[,] matrix = new int[rowsCols[0], rowsCols[1]];

        for (int i = 0; i < rowsCols[0]; i++)
        {
            int[] input = Console.ReadLine()
            .Split(", ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

            for (int j = 0; j < rowsCols[1]; j++)
            {
                matrix[i, j] = input[j];
            }
        }

        int maximumSum = int.MinValue;
        int RowIndex = 0;
        int ColumnIndex = 0;

        for (int i = 0; i < rowsCols[0] - 1; i++)
        {
            int currentSum = 0;
            for (int j = 0; j < rowsCols[1] - 1; j++)
            {
                currentSum = matrix[i, j] + matrix[i + 1, j] + matrix[i, j + 1] + matrix[i + 1, j + 1];

                if (currentSum > maximumSum)
                {
                    RowIndex = i;
                    ColumnIndex = j;
                    maximumSum = currentSum;
                }
            }
        }

        Console.WriteLine($"{matrix[RowIndex, ColumnIndex]} {matrix[RowIndex, ColumnIndex + 1]}");
        Console.WriteLine($"{matrix[RowIndex + 1, ColumnIndex]} {matrix[RowIndex + 1, ColumnIndex + 1]}");
        Console.WriteLine(maximumSum);
    }
}