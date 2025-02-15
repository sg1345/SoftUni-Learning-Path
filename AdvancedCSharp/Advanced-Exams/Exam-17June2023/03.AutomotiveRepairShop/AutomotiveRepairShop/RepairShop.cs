using System.Text;

namespace AutomotiveRepairShop
{
    public class RepairShop
    {
        public RepairShop(int capacity)
        {
            this.Capacity = capacity;
            this.Vehicles = new List<Vehicle>();
        }

        public int Capacity { get;}
        public List<Vehicle> Vehicles { get; set; }
        public int Count => this.Vehicles.Count;

        public void AddVehicle(Vehicle vehicle)
        {
            if (this.Vehicles.Any(x=>x.VIN == vehicle.VIN))
            {
                return;
            }

            if (this.Capacity > this.Count)
            {
                this.Vehicles.Add(vehicle);
            }
        }

        public bool RemoveVehicle(string vin)//
        {
            if (this.Vehicles.Any(vehicle => vehicle.VIN == vin))
            {
                var vehicle = this.Vehicles
                    .ElementAt(this.Vehicles.FindIndex(v => v.VIN == vin));

                return Vehicles.Remove(vehicle);

                //int index = this.Vehicles.FindIndex(vehicle => vehicle.VIN == vin);
                //this.Vehicles.RemoveAt(index);
                //return true;
            }

            return false;
        }

        public int GetCount()
        {
            return this.Count;
        }

        public Vehicle GetLowestMileage()
        {
            return this.Vehicles
                .OrderBy(vehicle => vehicle.Mileage)
                .FirstOrDefault();
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Vehicles in the preparatory:");

            foreach (var vehicle in this.Vehicles)
            {
                sb.AppendLine(vehicle.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
