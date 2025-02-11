namespace _05.GenericCountMethodString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine()!);

            List<string> array = new();

            for (int i = 0; i < number; i++)
            {
                string box = Console.ReadLine()!;

                array.Add(box);
            }

            Box<string> compater = new Box<string>(Console.ReadLine()!);

            Console.WriteLine(compater.CountLarger(array));
        }
    }
}
