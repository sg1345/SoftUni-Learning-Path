internal class Program
{
    static void Main()
    {
        int[] Length = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        string[,] matrix = new string[Length[0], Length[1]];

        for (int i = 0; i < Length[0]; i++)
        {
            string[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            for (int j = 0; j < Length[1]; j++)
            {
                matrix[i, j] = input[j];
            }
        }

        string command = string.Empty;
        while ((command = Console.ReadLine()) != "END")
        {
            string[] token = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string swapCommand = token[0];

            if(token.Length != 5 || swapCommand != "swap")
            {
                Console.WriteLine("Invalid input!");
                continue;
            }

            int row1 = int.Parse(token[1]);
            int col1 = int.Parse(token[2]);
            int row2 = int.Parse(token[3]);
            int col2 = int.Parse(token[4]);

            if (ItIsNotInTheMatrix(matrix, row1, col1, row2, col2))
            {
                Console.WriteLine("Invalid input!");
                continue;
            }


            string temp = matrix[row1, col1];
            matrix[row1, col1] = matrix[row2, col2];
            matrix[row2, col2] = temp;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }

    private static bool ItIsNotInTheMatrix(string[,] matrix, int row1, int col1, int row2, int col2)
    {
        return row1 > matrix.GetLength(0) - 1 || row1 < 0 
            || col1 > matrix.GetLength(1) - 1 || col1 < 0 
            || row2 > matrix.GetLength(0) - 1 || row2 < 0 
            || col2 > matrix.GetLength(1) - 1 || col1 < 0;
    }
}