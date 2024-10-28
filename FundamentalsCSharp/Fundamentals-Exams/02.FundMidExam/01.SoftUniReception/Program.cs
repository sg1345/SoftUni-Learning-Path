internal class Program
{
    static void Main()
    {
        int firstWorker = int.Parse(Console.ReadLine());
        int secondWorker = int.Parse(Console.ReadLine());
        int thirdWorker = int.Parse(Console.ReadLine());

        int students = int.Parse(Console.ReadLine());

        int hours = 0;
        while (students > 0)
        {
            hours++;

            if (hours % 4 == 0)
            {
                continue;
            }

            students -= (firstWorker + secondWorker + thirdWorker);
        }     

        Console.WriteLine($"Time needed: {hours}h.");
    }
}