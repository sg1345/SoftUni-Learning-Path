
using System.Diagnostics.Contracts;
internal class Program
{
    static void Main()
    {
        int length = int.Parse(Console.ReadLine());

        char[,] board = new char[length, length];

        for (int i = 0; i < board.GetLength(0); i++)
        {
            string input = Console.ReadLine();

            for (int j = 0; j < board.GetLength(1); j++)
            {
                board[i, j] = input[j];
            }
        }

        bool tryRemove = true;
        int removedCount = 0;
        while (tryRemove)
        {
            int maxRow = -1; int maxCol = -1;
            int maxConflictCounter = 0;

            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    int currentConflictCounter = 0;

                    if (board[row, col] != 'K')
                    {
                        continue;
                    }

                    currentConflictCounter += CheckForConflict(board, row - 2, col - 1);
                    currentConflictCounter += CheckForConflict(board, row - 2, col + 1);
                    currentConflictCounter += CheckForConflict(board, row - 1, col - 2);
                    currentConflictCounter += CheckForConflict(board, row - 1, col + 2);
                    currentConflictCounter += CheckForConflict(board, row + 1, col - 2);
                    currentConflictCounter += CheckForConflict(board, row + 1, col + 2);
                    currentConflictCounter += CheckForConflict(board, row + 2, col - 1);
                    currentConflictCounter += CheckForConflict(board, row + 2, col + 1);

                    if (currentConflictCounter > maxConflictCounter)
                    {
                        maxRow = row;
                        maxCol = col;
                        maxConflictCounter = currentConflictCounter;
                    }
                }
            }

            if (maxConflictCounter > 0)
            {
                board[maxRow, maxCol] = '0';
                removedCount++;
            }
            else
            {
                tryRemove = false;
            }
        }

        Console.WriteLine(removedCount);
    }

    static int CheckForConflict(char[,] board, int row, int col)
    {
        if (row >= 0 && row < board.GetLength(0) &&
            col < board.GetLength(1) && col >= 0)
        {
            if (board[row, col] == 'K')
            {
                return 1;
            }
        }
        return 0;
    }
}