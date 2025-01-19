internal class Program
{
    static void Main()
    {
        int rowLength = int.Parse(Console.ReadLine());

        int[][] jagged = new int[rowLength][];

        for (int i = 0; i < rowLength; i++)
        {
            int[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            jagged[i] = new int[input.Length];

            for (int j = 0; j < input.Length; j++)
            {
                jagged[i][j] = input[j];
            }
        }

        for (int i = 0; i < jagged.GetLength(0) - 1; i++)
        {
            if (jagged[i].Length == jagged[i + 1].Length)
            {
                for (int j = 0; j < jagged[i].Length; j++)
                {
                    jagged[i][j] *= 2;
                    jagged[i + 1][j] *= 2;
                }
            }
            else
            {
                for (int j = 0; j < jagged[i].Length; j++)
                {
                    jagged[i][j] /= 2;
                }

                jagged[i + 1] = jagged[i + 1].Select(x => x /= 2).ToArray();
            }
        }

        string command = string.Empty;
        while ((command = Console.ReadLine()) != "End")
        {
            string[] token = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            int row = int.Parse(token[1]);
            int col = int.Parse(token[2]);
            int number = int.Parse(token[3]);

            switch (token[0])
            {
                case "Add":

                    if (jagged.GetLength(0) > row && row > -1 &&
                        jagged[row].Length > col && col > -1)
                    {
                        jagged[row][col] += number;
                    }

                    break;

                case "Subtract":

                    if (jagged.GetLength(0) > row && row > -1 &&
                        jagged[row].Length > col && col > -1)
                    {
                        jagged[row][col] -= number;
                    }

                    break;
            }
        }

        for (int i = 0; i < jagged.GetLength(0); i++)
        {
            Console.WriteLine(string.Join(' ', jagged[i]));
        }

    }
}