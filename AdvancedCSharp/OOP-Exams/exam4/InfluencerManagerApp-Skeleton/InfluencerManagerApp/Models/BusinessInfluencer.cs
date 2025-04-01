﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfluencerManagerApp.Models
{
    public class BusinessInfluencer : Influencer
    {
        private const double engagementRate = 3.0;
        private const double factor = 0.15;
        public BusinessInfluencer(string username, int followers) : base(username, followers, engagementRate)
        {
        }

        public override int CalculateCampaignPrice() => (int)Math.Floor(this.Followers * this.EngagementRate * factor);
    }
}
