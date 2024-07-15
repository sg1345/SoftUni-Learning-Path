internal class Program
{
    static void Main()
    {
        //1 4 3 2 
        var array = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();

        for (int i = 0; i < array.Length; i++)
        {
            if (i == array.Length - 1)
            {
                Console.Write(array[i]);
            }
            else
            {
                if (array[i] > array[i + 1])
                {
                    Console.Write(array[i] + " ");
                }
            }
        }
    }
}