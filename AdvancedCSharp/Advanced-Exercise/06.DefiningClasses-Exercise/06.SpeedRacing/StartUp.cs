namespace _06.SpeedRacing
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < number; i++)
            {
                string[] info = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string model = info[0];
                double fuelAmount = double.Parse(info[1]);
                double fuelConsumptionPerKm = double.Parse(info[2]);

                Car car = new Car(model, fuelAmount, fuelConsumptionPerKm);

                cars.Add(car);
            }

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] Command = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string carModel = Command[1];
                double amountOfKM = double.Parse(Command[2]);

                if (Command[0] == "Drive")
                {
                    int currentCarIndex = cars.FindIndex(car => car.Model == carModel);                    
                    if (currentCarIndex >= 0)
                    {
                        cars[currentCarIndex].Drive(amountOfKM);
                    }
                }
            }

            foreach (Car car in cars)
            {
                car.Print();
            }
        }
    }
}