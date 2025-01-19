internal class Program
{
    static void Main()
    {
        int[] Length = Console.ReadLine()
        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
        .Select(int.Parse)
        .ToArray();

        string word = Console.ReadLine();
        int currentIndexCount = 0;

        char[,] matrix = new char[Length[0], Length[1]];

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            if (i % 2 == 0)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = word[currentIndexCount];
                    currentIndexCount = SnakeMoveController(word, currentIndexCount);
                }
            }
            else
            {
                for (int j = matrix.GetLength(1) - 1; j >= 0; j--)
                {
                    matrix[i, j] = word[currentIndexCount];
                    currentIndexCount = SnakeMoveController(word, currentIndexCount);
                }
            }
        }

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write($"{matrix[i, j]}");
            }
            Console.WriteLine();
        }

    }

    static int SnakeMoveController(string word, int currentIndexCount)
    {
        currentIndexCount++;

        if (currentIndexCount == word.Length)
        {
            currentIndexCount = 0;
        }

        return currentIndexCount;
    }
}