internal class Program
{
    static void Main()
    {
        int countLines = int.Parse(Console.ReadLine());

        char[,] matrix = new char[countLines,countLines];

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            string input = Console.ReadLine();
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                matrix[i,j] = input[j];
            }
        }

        char searchedSymbol = char.Parse(Console.ReadLine());

        for (int i = 0;i < matrix.GetLength(0); i++)
        {
            for (int j = 0;j < matrix.GetLength(1); j++)
            {
                if(matrix[i,j] == searchedSymbol)
                {
                    Console.WriteLine($"({i}, {j})");
                    return;
                }
            }
        }

        Console.WriteLine($"{searchedSymbol} does not occur in the matrix");
    }
}