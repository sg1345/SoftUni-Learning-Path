internal class Program
{
    static void Main()
    {
        int numberOfRows = int.Parse(Console.ReadLine());

        long[][] pascalTriangle = new long[numberOfRows][];
        for (int row = 0; row < pascalTriangle.GetLength(0); row++)
        {
            int colLength = row + 1;
            pascalTriangle[row] = new long[colLength];

            for (int col = 0; col < colLength; col++)
            {
                if (col == 0 || col == colLength - 1)
                {
                    pascalTriangle[row][col] = 1;
                    continue;
                }
                pascalTriangle[row][col] = pascalTriangle[row - 1][col] + pascalTriangle[row - 1][col - 1];
            }
        }

        for (int row = 0; row < pascalTriangle.GetLength(0); row++)
        {
            int colLength = row + 1;

            Console.WriteLine(string.Join(' ', pascalTriangle[row]));

        }
    }
}