
internal class Program
{
    static void Main()
    {
        int[] raceTrack = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        double finalTimeLeft = LeftTrackChronometer(raceTrack);

        double finalTimeRight = RightTrackChronometer(raceTrack);

        PrintWinner(finalTimeLeft, finalTimeRight);
    }

    static double LeftTrackChronometer(int[] raceTrack)
    {
        double finalTime = 0;
        for (int i = 0; i < raceTrack.Length / 2; i++)
        {
            int left = raceTrack[i];

            finalTime += left;

            if (left == 0)
            {
                finalTime -= finalTime * 0.2;
            }
        }

        return finalTime;
    }

    private static double RightTrackChronometer(int[] raceTrack)
    {
        double finalTime = 0;
        for (int i = raceTrack.Length - 1; i > raceTrack.Length / 2; i--)
        {
            int right = raceTrack[i];

            finalTime += right;

            if (right == 0)
            {
                finalTime -= finalTime * 0.2;
            }
        }

        return finalTime;
    }

    static void PrintWinner(double finalTimeLeft, double finalTimeRight)
    {
        if (finalTimeLeft < finalTimeRight)
        {
            Console.WriteLine($"The winner is left with total time: {finalTimeLeft}");
        }
        else
        {
            Console.WriteLine($"The winner is right with total time: {finalTimeRight}");
        }
    }
}
