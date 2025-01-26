internal class Program
{
    static void Main()
    {
        HashSet<string> parkingLot = new();
        string input = string.Empty;
        while((input = Console.ReadLine()) != "END")
        {
            string[] command = input.Split(", ",StringSplitOptions.RemoveEmptyEntries);

            string direction = command[0];
            string carNumber = command[1];

            if (direction == "IN")
            {
                parkingLot.Add(carNumber);
            }
            if (direction == "OUT")
            {
                parkingLot.Remove(carNumber);
            }
        }

        if (parkingLot.Count == 0)
        {
            Console.WriteLine("Parking Lot is Empty");
            return;
        }

        foreach (string car in parkingLot)
        {
            Console.WriteLine(car);
        }
    }
}