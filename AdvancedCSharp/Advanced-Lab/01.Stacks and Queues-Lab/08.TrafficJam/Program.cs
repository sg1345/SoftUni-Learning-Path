internal class Program
{
    static void Main()
    {
        int countGreenLineCarPass = int.Parse(Console.ReadLine());

        Queue<string> trafficJam = new();

        int carPassed = 0;
        string command = string.Empty;
        while ((command = Console.ReadLine()) != "end")
        {
            if (command == "green")
            {
                int currentCar = 0;
                while (currentCar != countGreenLineCarPass && trafficJam.Count > 0)
                {
                    Console.WriteLine($"{trafficJam.Dequeue()} passed!");

                    currentCar++;
                }

                carPassed += currentCar;
                continue;
            }

            trafficJam.Enqueue(command);
        }

        Console.WriteLine($"{carPassed} cars passed the crossroads.");
    }
}
