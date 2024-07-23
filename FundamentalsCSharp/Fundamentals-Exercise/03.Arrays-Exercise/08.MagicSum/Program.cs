internal class Program
{
    static void Main()
    {
        var array = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();

        var magicSum = int.Parse(Console.ReadLine());

        for (int i = 0; i < array.Length; i++)
        {
            for (int j = i + 1; j < array.Length; j++)
            {
                if (array[i] + array[j] == magicSum)
                {
                    Console.WriteLine($"{array[i]} {array[j]}");
                }
            }
        }
    }
}