class Vehicle
{
    public Vehicle(string type, string model, string color, int horsePower)
    {
        type = char.ToUpper(type[0]) + type.Substring(1);

        Type = type;
        Model = model;
        Color = color;
        HorsePower = horsePower;
    }
    public string Type;
    public string Model;
    public string Color;
    public int HorsePower;

    public static double AverageHorsePower(List<Vehicle> vehicles, string typeOfVehicle)
    {

        List<Vehicle> filteredVehicles = vehicles
           .Where(vehicle => vehicle.Type == typeOfVehicle)
           .ToList();

        if (filteredVehicles.Count == 0)
        {
            return 0; 
        }

        return filteredVehicles.Average(vehicle => vehicle.HorsePower);
    }

    public void Print()
    {
        Console.WriteLine
    (
        $"Type: {Type}\n" +
        $"Model: {Model}\n" +
        $"Color: {Color}\n" +
        $"Horsepower: {HorsePower}"
    );
    }
}

internal class Program
{
    static void Main()
    {
        List<Vehicle> vehicles = new();

        string input = string.Empty;
        while ((input = Console.ReadLine()) != "End")
        {
            string[] info = input.Split().Select(text => text.Trim()).ToArray();

            Vehicle currentVehicle = new(info[0], info[1], info[2], int.Parse(info[3]));
            vehicles.Add(currentVehicle);
        }

        input = string.Empty;
        while ((input = Console.ReadLine()) != "Close the Catalogue")
        {
            Vehicle pickedVehicle = vehicles.Find(vehicle => vehicle.Model == input);

            pickedVehicle.Print();


        }

        double truckAverageHorsePower = Vehicle.AverageHorsePower(vehicles, "Truck");
        double carAverageHorsePower = Vehicle.AverageHorsePower(vehicles, "Car");

        Console.WriteLine($"Cars have average horsepower of: {carAverageHorsePower:f2}.");
        Console.WriteLine($"Trucks have average horsepower of: {truckAverageHorsePower:f2}.");
    }
}