internal class Program
{
    static void Main()
    {
        int rows = int.Parse(Console.ReadLine());

        int[][] jagged = new int[rows][];

        for (int i = 0; i < rows; i++)
        {
            int[] array = Console.ReadLine()
                .Split().
                Select(int.Parse)
                .ToArray();
            jagged[i] = new int[array.Length];
            int text = jagged[i].Length;

            for (int j = 0; j < jagged[i].Length; j++)
            {
                jagged[i][j] = array[j];
            }
        }
        int a = jagged.Rank;
        int b = jagged.GetLength(0);
        string input = string.Empty;
        while ((input = Console.ReadLine()) != "END")
        {
            string[] command = input.Split();

            switch (command[0])
            {
                case "Add":
                    int row = int.Parse(command[1]);
                    int col = int.Parse(command[2]);
                    int number = int.Parse(command[3]);

                    if (jagged.GetLength(0) > row && row > -1 &&
                        jagged[row].Length > col && col > -1)
                    {
                        jagged[row][col] += number;
                        continue;
                    }
                    Console.WriteLine("Invalid coordinates");

                    break;

                case "Subtract":
                    row = int.Parse(command[1]);
                    col = int.Parse(command[2]);
                    number = int.Parse(command[3]);

                    if (jagged.GetLength(0) > row && row > -1 &&
                        jagged[row].Length > col && col > -1)
                    {
                        jagged[row][col] -= number;
                        continue;
                    }
                    Console.WriteLine("Invalid coordinates");

                    break;
            }
        }

        for (int i = 0; i < jagged.GetLength(0); i++)
        {
            Console.WriteLine(string.Join(" ", jagged[i]));
        }
    }
}