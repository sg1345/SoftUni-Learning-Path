internal class Program
{
    static void Main()
    {
        Queue <string> queue = new(Console.ReadLine().Split());

        int HotPatatoNumber = int.Parse(Console.ReadLine());
        int currentPatatoNumber = 0;
        while (queue.Count > 1)
        {
            currentPatatoNumber++;
            string currentPlayer = queue.Dequeue();

            if (currentPatatoNumber < HotPatatoNumber)
            {
                queue.Enqueue(currentPlayer);
                continue;
            }

            Console.WriteLine($"Removed {currentPlayer}");
            currentPatatoNumber = 0;
        }

        Console.WriteLine($"Last is {queue.Dequeue()}");
    }
}
