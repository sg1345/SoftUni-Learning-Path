class TruckTourStop
{
    public TruckTourStop(int fuel, int distance)
    {
        Fuel = fuel;
        Distance = distance;
    }

    public int Fuel {  get; set; }
    public int Distance { get; set; }

}

internal class Program
{
    static void Main()
    {
        Queue<TruckTourStop> truckTour = new Queue<TruckTourStop>();

        int numberOfStops = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfStops; i++)
        {
            int[] info = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            TruckTourStop currentStopInfo = new(info[0], info[1]);

            truckTour.Enqueue(currentStopInfo);
        }

        for (int i = 0; i < numberOfStops; i++)
        {
            int actualFuel = 0;
            bool isPossible = true;
            for (int j = 0; j < numberOfStops; j++)
            {
                TruckTourStop UntilNextStop = truckTour.Dequeue();
                truckTour.Enqueue(UntilNextStop);

                actualFuel += UntilNextStop.Fuel;
                actualFuel -= UntilNextStop.Distance;
                
                if (actualFuel < 0)
                {
                    isPossible = false;
                }

            }

            if (isPossible)
            {
                Console.WriteLine(i);
                break;
            }

            truckTour.Enqueue(truckTour.Dequeue());
        }

    }
}