internal class Program
{
    static void Main()
    {
        Queue<int> ints = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));


        while (ints.Count > 0)
        {
            int currentNumber = ints.Dequeue();
            if (currentNumber % 2 == 0)
            {
                Console.Write($"{currentNumber}");
                if (ints.Count != 0)
                {
                    Console.Write(", ");
                }
            }

        }
    }
}