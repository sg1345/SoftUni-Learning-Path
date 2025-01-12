internal class Program
{
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
            .Split()
            .Select(int.Parse)
            .ToArray();

            for (int j = 0; j < input.Length; j++)
            {
                matrix[i, j] = input[j];
            }
        }

        for (int i = 0; i < matrix.GetLength(1); i++)
        {
            int sum = 0;
            for (int j = 0; j < matrix.GetLength(0); j++)
            {
                sum += matrix[j, i];
            }
            Console.WriteLine(sum);
        }
    }
}
