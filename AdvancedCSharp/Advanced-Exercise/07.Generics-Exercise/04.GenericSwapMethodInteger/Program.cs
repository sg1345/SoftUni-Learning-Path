namespace _04.GenericSwapMethodInteger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            Box<int>[] array = new Box<int>[number];

            for (int i = 0; i < number; i++)
            {
                array[i] = new(int.Parse(Console.ReadLine()));
            }

            int[] ints = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Box.Swap(array, ints[0], ints[1]);

            foreach (var box in array)
            {
                Console.WriteLine(box);
            }
        }
    }
}
