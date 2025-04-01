using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfluencerManagerApp.Models
{
    public abstract class Influencer : IInfluencer
    {
        private string username;
        private int followers;
        private List<string> participations;

        public Influencer(string username, int followers, double engagementRate)
        {
            this.participations = new List<string>();
            Username = username;
            Followers = followers;
            EngagementRate = engagementRate;
        }

        public string Username
        {
            get { return username; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(ExceptionMessages.UsernameIsRequired);


                username = value;
            }
        }

        public int Followers
        {
            get { return followers; }
            private set
            {
                if (value < 0)
                    throw new ArgumentException(ExceptionMessages.FollowersCountNegative);

                followers = value;
            }
        }

        public double EngagementRate { get; private set; }

        public double Income { get; private set; } = 0;

        public IReadOnlyCollection<string> Participations => participations.AsReadOnly();

        public abstract int CalculateCampaignPrice();

        public void EarnFee(double amount)
        {
            this.Income += amount;
        }

        public void EndParticipation(string brand)
        {
            participations.Remove(brand);
        }

        public void EnrollCampaign(string brand)
        {
            participations.Add(brand);
        }

        public override string ToString() => $"{Username} - Followers: {Followers}, Total Income: {Income}";
    }
}
