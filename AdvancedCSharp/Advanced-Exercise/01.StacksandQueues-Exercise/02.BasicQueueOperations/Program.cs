internal class Program
{
    static void Main()
    {
        int[] operations = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();

        int[] numbers = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();

        Queue<int> stack = new();
        for (int i = 0; i < operations[0]; i++)
        {
            stack.Enqueue(numbers[i]);
        }

        for (int i = 0; i < operations[1]; i++)
        {
            stack.Dequeue();
        }

        int minNumber = int.MaxValue;

        if (stack.Count == 0)
        {
            Console.WriteLine(0);
            return;
        }

        while (stack.Count > 0)
        {
            if (stack.Peek() == operations[2])
            {
                Console.WriteLine("true");
                return;
            }

            if (stack.Peek() < minNumber)
            {
                minNumber = stack.Dequeue();
                continue;
            }

            stack.Dequeue();
        }
        Console.WriteLine(minNumber);
    }
}
