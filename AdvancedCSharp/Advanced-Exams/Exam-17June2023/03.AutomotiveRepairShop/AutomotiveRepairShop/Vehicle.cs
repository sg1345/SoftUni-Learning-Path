namespace AutomotiveRepairShop
{
    public class Vehicle
    {
        public Vehicle(string vin, int milaege, string damage)
        {
            this.VIN = vin;
            this.Mileage = milaege;
            this.Damage = damage;
        }

        public string VIN { get; }
        public int Mileage { get; }
        public string Damage { get; }

        public override string ToString()
        {
            return $"Damage: {this.Damage}, Vehicle: {this.VIN} ({this.Mileage} km)";
        }
    }
}
