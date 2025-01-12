internal class Program
{
    static void Main()
    {
        int countLines = int.Parse(Console.ReadLine());

        int[,] matrix = new int[countLines, countLines];

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            int[] input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                matrix[i, j] = input[j];
            }
        }

        int sum = 0;
        for (int i = 0; i < countLines; i++)
        {
            sum += matrix[i, i];
        }
        Console.WriteLine(sum);
    }
}
