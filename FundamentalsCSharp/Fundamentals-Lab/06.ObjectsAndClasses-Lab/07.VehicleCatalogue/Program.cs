using System.Reflection;

internal class Program
{
    static void Main()
    {
        Catalog vehicles = new();
        vehicles.Cars = new();
        vehicles.Trucks = new();

        string input = string.Empty;
        while ((input = Console.ReadLine()) != "end")
        {
            string[] info = input.Split('/');

            switch (info[0])
            {
                case "Car":
                    AddCarToTheCatalog(vehicles, info);
                    break;

                case "Truck":
                    AddTruckToTheCatalog(vehicles, info);
                    break;
            }
        }

        if (vehicles.Cars.Count != 0)
        {
            PrindCars(vehicles);
        }

        if (vehicles.Trucks.Count != 0)
        {
            PrintTrucks(vehicles);
        }
    }

    static void AddCarToTheCatalog(Catalog vehicles, string[] info)
    {
        Car newCar = new();
        newCar.Brand = info[1];
        newCar.Model = info[2];
        newCar.HorsePower = info[3];

        vehicles.Cars.Add(newCar);
    }

    static void AddTruckToTheCatalog(Catalog vehicles, string[] info)
    {
        Truck newTruck = new();
        newTruck.Brand = info[1];
        newTruck.Model = info[2];
        newTruck.Weight = info[3];

        vehicles.Trucks.Add(newTruck);
    }

    static void PrindCars(Catalog vehicles)
    {
            Console.WriteLine("Cars:");

            vehicles.Cars = vehicles.Cars.OrderBy(x => x.Brand).ToList();

            foreach (Car car in vehicles.Cars)
            {
                if (car != null)
                {
                    Console.WriteLine($"{car.Brand}: {car.Model} - {car.HorsePower}hp");
                }
            }        
    }

    static void PrintTrucks(Catalog vehicles)
    {
        Console.WriteLine("Trucks:");

        vehicles.Trucks = vehicles.Trucks.OrderBy(x => x.Brand).ToList();

        foreach (Truck truck in vehicles.Trucks)
        {
            if (truck != null)
            {
                Console.WriteLine($"{truck.Brand}: {truck.Model} - {truck.Weight}kg");
            }
        }
    }
}

class Truck
{
    public string Brand { get; set; }
    public string Model { get; set; }
    public string Weight { get; set; }
}

class Car
{
    public string Brand { get; set; }
    public string Model { get; set; }
    public string HorsePower { get; set; }
}

class Catalog
{
    public List<Car> Cars { get; set; }
    public List<Truck> Trucks { get; set; }
}