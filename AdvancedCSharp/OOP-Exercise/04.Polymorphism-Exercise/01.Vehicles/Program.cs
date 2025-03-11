namespace _01.Vehicles
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
            string[] input = Console.ReadLine()!
                .Split(' ',StringSplitOptions.RemoveEmptyEntries);
            
            IVehicle car = new Car(double.Parse(input[1]), double.Parse(input[2]));

            input = Console.ReadLine()!
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            IVehicle truck = new Truck(double.Parse(input[1]), double.Parse(input[2]));

            int number = int.Parse(Console.ReadLine());
            for(int i = 0; i < number; i++)
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
            }
            Console.WriteLine(car);
            Console.WriteLine(truck);
        }

        private static void Actions(IVehicle car, string[] data)
        {
            if (data[0] == "Drive")
            {
                car.Drive(double.Parse(data[2]));
            }
            else if (data[0] == "Refuel")
            {
                car.Refuel(double.Parse(data[2]));
            }
        }
    }
}
