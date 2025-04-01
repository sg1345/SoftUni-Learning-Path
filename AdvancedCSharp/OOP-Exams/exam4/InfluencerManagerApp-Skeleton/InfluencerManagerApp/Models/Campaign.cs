using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfluencerManagerApp.Models
{
    public abstract class Campaign : ICampaign
    {
        private string brand;
        private List<string> contributors;

        public Campaign( string brand, double budget)
        {
            this.contributors = new List<string>();
            Brand = brand;
            Budget = budget;
        }

        public string Brand 
        { 
            get { return brand; }
            private set 
            { 
                if (string.IsNullOrWhiteSpace(value)) 
                    throw new ArgumentException(ExceptionMessages.BrandIsrequired);
                brand = value;
            }
        }

        public double Budget { get; private set; }

        public IReadOnlyCollection<string> Contributors => contributors.AsReadOnly();

        public void Engage(IInfluencer influencer)
        {
            contributors.Add(influencer.Username);
            Budget -= influencer.CalculateCampaignPrice();
        }

        public void Gain(double amount)
        {
            this.Budget += amount;
        }

        public override string ToString()
        {
            string campaignTypeName = this.GetType().Name;

            return $"{campaignTypeName} - Brand: {Brand}, Budget: {Budget}, Contributors: {Contributors.Count}";
        }
    }
}
