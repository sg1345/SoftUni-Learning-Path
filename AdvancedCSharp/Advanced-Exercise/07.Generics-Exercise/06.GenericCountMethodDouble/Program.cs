namespace _06.GenericCountMethodDouble
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine()!);

            List<double> array = new();

            for (int i = 0; i < number; i++)
            {
                double box = double.Parse(Console.ReadLine()!);

                array.Add(box);
            }

            Box<double> comparer = new(double.Parse(Console.ReadLine()));

            Console.WriteLine(comparer.CountLarger(array));
        }

        public static void Swap<T>(T[] array, int index1, int index2)
        {
            (array[index1], array[index2]) = (array[index2], array[index1]);
        }
    }
}
