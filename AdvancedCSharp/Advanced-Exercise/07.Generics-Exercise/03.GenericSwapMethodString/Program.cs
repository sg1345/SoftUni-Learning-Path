namespace _03.GenericSwapMethodString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            Box<string>[] array = new Box<string>[number]; 

            for (int i = 0; i < number; i++)
            {
                array[i] = new (Console.ReadLine());
            }

            int[] ints = Console.ReadLine()
                .Split(' ',StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

           Box<string>.Swap(array, ints[0], ints[1]);

            foreach(var box in array)
            {
                Console.WriteLine(box);
            }
        }
    }
}

