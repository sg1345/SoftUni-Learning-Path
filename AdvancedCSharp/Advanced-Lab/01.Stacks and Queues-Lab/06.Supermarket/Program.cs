internal class Program
{
    static void Main()
    {
        Queue<string> queue = new();

        string command = string.Empty;
        while ((command = Console.ReadLine()) != "End")
        {
            if (command == "Paid")
            {
                while (queue.Count > 0)
                {
                    Console.WriteLine(queue.Dequeue());
                }
                continue;
            }            
            queue.Enqueue(command);
        }
        
        Console.WriteLine($"{queue.Count} people remaining.");
    }
}
