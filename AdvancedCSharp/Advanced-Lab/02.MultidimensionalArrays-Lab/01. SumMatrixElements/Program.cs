internal class Program
{
    static void Main()
    {
        int[] rowsCols = Console.ReadLine()
            .Split(", ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        int[,] matrix = new int[rowsCols[0], rowsCols[1]];

        int sum = 0;
        for (int i = 0; i < rowsCols[0]; i++)
        {
            int[] input = Console.ReadLine()
            .Split(", ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

            for (int j = 0; j < input.Length; j++)
            {
                matrix[i, j] = input[j];
                sum += matrix[i, j];
            }

        }
        Console.WriteLine(rowsCols[0]);
        Console.WriteLine(rowsCols[1]);
        Console.WriteLine(sum);
    }
}
