namespace EstateAgency
{
    public class RealEstate
    {
        public RealEstate(string address, string postalCode, decimal price, double size)
        {
            this.Address = address;
            this.PostalCode = postalCode;
            this.Price = price;
            this.Size = size;
        }

        public string Address { get; }
        public string PostalCode { get; }
        public decimal Price { get; }
        public double Size { get; }

        public override string ToString()
        {
            return $"Address: {this.Address}, PostalCode: {this.PostalCode}," +
                $" Price: ${this.Price}, Size: {this.Size} sq.m.";
        }
    }
}
