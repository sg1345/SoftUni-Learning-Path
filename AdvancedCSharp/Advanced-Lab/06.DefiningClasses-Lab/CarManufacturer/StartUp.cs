using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Tire[]> listOfTires = new List<Tire[]>();

            string input;
            while ((input = Console.ReadLine()) != "No more tires")
            {
                string[] command = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                int firstTireYear = int.Parse(command[0]);
                int secondTireYear = int.Parse(command[2]);
                int thirdTireYear = int.Parse(command[4]);
                int fourthTireYear = int.Parse(command[6]);

                double firstTirePressure = double.Parse(command[1]);
                double secondTirePressure = double.Parse(command[3]);
                double thirdTirePressure = double.Parse(command[5]);
                double fourthTirePressure = double.Parse(command[7]);

                Tire[] tires = new Tire[4]
                {
                    new Tire(firstTireYear,firstTirePressure),
                    new Tire(secondTireYear,secondTirePressure),
                    new Tire(thirdTireYear,thirdTirePressure),
                    new Tire(fourthTireYear,fourthTirePressure),
                };

                listOfTires.Add(tires);
            }

            List<Engine> listOfEngines = new List<Engine>();

            while ((input = Console.ReadLine()) != "Engines done")
            {
                string[] command = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                int horsePower = int.Parse(command[0]);
                double cubicCapacity = double.Parse(command[1]);

                Engine newEngine = new Engine(horsePower, cubicCapacity);

                listOfEngines.Add(newEngine);
            }

            List<Car> carCollection = new List<Car>();


            while ((input = Console.ReadLine()) != "Show special")
            {
                string[] command = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string make = command[0];
                string model = command[1];
                int year = int.Parse(command[2]);
                double fuelQuantity = double.Parse(command[3]);
                double fuelConsumption = double.Parse(command[4]);
                int engineIndex = int.Parse(command[5]);
                int tiresIndex = int.Parse(command[6]);

                Car car = new Car(make, model, year, fuelQuantity, fuelConsumption,
                    listOfEngines[engineIndex], listOfTires[tiresIndex]);

                carCollection.Add(car);
            }

            for (int i = 0; i < carCollection.Count; i++)
            {
                if (carCollection[i].Year >= 2017 && 
                    carCollection[i].Engine.HorsePower > 330 &&
                    carCollection[i].TiresPressureSum()>=9 &&
                    carCollection[i].TiresPressureSum()<=10)
                {
                    carCollection[i].Drive(20);

                    carCollection[i].SpecialCarPrint();

                }
            }

        }
    }
}
