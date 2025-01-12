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

        Stack<int> stack = new Stack<int>();
        for (int i = 0; i < operations[0]; i++)
        { 
            stack.Push(numbers[i]);
        }

        for (int i = 0;i < operations[1]; i++)
        {
            stack.Pop();
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
                minNumber = stack.Pop();
                continue;
            }

            stack.Pop();
        }
        Console.WriteLine(minNumber);
    }
}
