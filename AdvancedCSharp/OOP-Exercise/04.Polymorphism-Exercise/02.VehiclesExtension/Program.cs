namespace _02.VehiclesExtension
{
    public class Program
    {
        public static void Main()
        {

            string[] input = Console.ReadLine()!
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            IVehicle car = new Car(double.Parse(input[1]), double.Parse(input[2]), double.Parse(input[3]));

            input = Console.ReadLine()!
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            IVehicle truck = new Truck(double.Parse(input[1]), double.Parse(input[2]), double.Parse(input[3]));

            input = Console.ReadLine()!
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            IVehicle bus = new Bus(double.Parse(input[1]), double.Parse(input[2]), double.Parse(input[3]));

            int number = int.Parse(Console.ReadLine()!);
            for (int i = 0; i < number; i++)
            {
                string[] data = input = Console.ReadLine()!
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (data[1] == "Car")
                {
                    Actions(car, data);
                }
                else if (data[1] == "Truck")
                {
                    Actions(truck, data);
                }
                else if (data[1] == "Bus")
                {
                    Actions(bus, data);
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }

        private static void Actions(IVehicle vechicle, string[] data)
        {
            if (data[0] == "DriveEmpty")
            {
                Bus? busTemp;
                busTemp = vechicle as Bus;

                busTemp!.DriveEmpty(double.Parse(data[2]));

                vechicle = busTemp;
                return;
            }

            if (data[0] == "Drive")
            {
                vechicle.Drive(double.Parse(data[2]));
            }
            else if (data[0] == "Refuel")
            {
                vechicle.Refuel(double.Parse(data[2]));
            }
            
        }
    }
}
