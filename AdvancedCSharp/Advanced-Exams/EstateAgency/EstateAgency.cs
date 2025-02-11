using System.Text;
using System.Xml;

namespace EstateAgency
{
    public class EstateAgency
    {
        public EstateAgency(int capacity)
        {
            this.Capacity = capacity;
            this.RealEstates = new();
        }

        public int Capacity { get; set; }
        public List<RealEstate> RealEstates { get; set; }
        public int Count => RealEstates.Count;

        public void AddRealEstate(RealEstate realEstate)
        {
            if (this.Count == this.Capacity ||
                this.RealEstates.Any(estate => estate.Address == realEstate.Address))
            {
                return;
            }
            this.RealEstates.Add(realEstate);
        }

        public bool RemoveRealEstate(string address)
        {
            if (this.RealEstates.Any(estate => estate.Address == address))
            {
                int index = this.RealEstates.
                    FindIndex(estate => estate.Address == address);

                this.RealEstates.RemoveAt(index);
                
                return true;
            }
            return false;
        }

        public List<RealEstate> GetRealEstates(string postalCode)
        {           
            return this.RealEstates
             .Where(estate => estate.PostalCode == postalCode)
             .ToList();           
        }

        public RealEstate GetCheapest()
        {
            return this.RealEstates.OrderBy(estate => estate.Price).FirstOrDefault()!;
        }

        public double GetLargest()
        {
            RealEstate largest = this.RealEstates
                .OrderByDescending(estate => estate.Size)
                .FirstOrDefault()!;

            return largest.Size;
        }

        public string EstateReport() //
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Real estates available:");

            foreach (RealEstate realEstate in this.RealEstates)
            {
                sb.AppendLine(realEstate.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
