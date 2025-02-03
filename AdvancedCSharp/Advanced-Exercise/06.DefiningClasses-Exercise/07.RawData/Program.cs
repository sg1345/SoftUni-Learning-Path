namespace _07.RawData
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < number; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string model = input[0];

                Engine engine = new(int.Parse(input[1]), int.Parse(input[2]));

                Cargo cargo = new(int.Parse(input[3]), input[4]);

                Tire[] tires = new Tire[4];

                tires[0] = new(double.Parse(input[5]), int.Parse(input[6]));
                tires[1] = new(double.Parse(input[7]), int.Parse(input[8]));
                tires[2] = new(double.Parse(input[9]), int.Parse(input[10]));
                tires[3] = new(double.Parse(input[11]),int.Parse(input[12]));

                Car car = new(model, engine, cargo, tires);

                cars.Add(car);
            }

            string command = Console.ReadLine();

            foreach (Car car in cars)
            {
                car.PrintModelFiteredByCargo(command);
            }

        }
    }
}
