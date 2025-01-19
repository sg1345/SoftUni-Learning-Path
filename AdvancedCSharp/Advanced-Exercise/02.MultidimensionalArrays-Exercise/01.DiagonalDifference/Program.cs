internal class Program
{
    static void Main()
    {
        int length = int.Parse(Console.ReadLine());

        int[,] matrix = new int[length, length];

        for (int i = 0; i < length; i++)
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

        int leftSum = 0;
        for (int i = 0; i < length; i++)
        {
            leftSum += matrix[i, i];
        }

        int rightSum = 0;
        for (int i = 0, j = length - 1; i < length && j >= 0; i++, j--)
        {
            rightSum += matrix[i, j];
        }

        Console.WriteLine(Math.Abs(leftSum-rightSum));
    }
}