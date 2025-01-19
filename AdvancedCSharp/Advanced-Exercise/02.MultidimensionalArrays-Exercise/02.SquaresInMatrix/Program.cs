internal class Program
{
    static void Main()
    {
        int[] Length = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        char[,] matrix = new char[Length[0], Length[1]];

        for (int i = 0; i < Length[0]; i++)
        {
            char[] input = Console.ReadLine()
                .Split(' ',StringSplitOptions.RemoveEmptyEntries)
                .Select(char.Parse)
                .ToArray();

            for (int j = 0; j < Length[1]; j++)
            {
                matrix[i, j] = input[j];
            }
        }
        int count = 0;
        for (int i = 0; i < matrix.GetLength(0) - 1; i++)
        {
            for (int j = 0; j < matrix.GetLength(1) - 1; j++)
            {
                if (matrix[i, j] == matrix[i, j + 1] &&
                    matrix[i, j] == matrix[i + 1, j] &&
                    matrix[i, j] == matrix[i + 1, j + 1])
                {
                    count++;
                }
            }
        }

        Console.WriteLine(count);
    }
}
