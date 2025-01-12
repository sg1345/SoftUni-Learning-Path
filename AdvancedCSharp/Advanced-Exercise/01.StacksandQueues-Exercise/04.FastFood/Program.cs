using System.Collections;

internal class Program
{
    static void Main()
    {
        int preparedFood = int.Parse(Console.ReadLine());

        Queue<int> queue = new(Console.ReadLine().Split().Select(int.Parse));

        int biggestOrder = 0;
        for(int i = 0; i < queue.Count; i++)
        {
            if (queue.Peek() > biggestOrder)
            {
                biggestOrder = queue.Peek();
            }
            queue.Enqueue(queue.Dequeue());
        }
        Console.WriteLine(biggestOrder);

        while (queue.Count > 0 && preparedFood >= queue.Peek())
        {
            preparedFood -= queue.Dequeue();
        }

        if (queue.Count > 0)
        {
            Console.WriteLine($"Orders left: {string.Join(' ', queue)}");
            return;
        }

        Console.WriteLine("Orders complete");
    }
}