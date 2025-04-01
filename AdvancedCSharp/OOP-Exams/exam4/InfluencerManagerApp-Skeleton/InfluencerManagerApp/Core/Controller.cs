using InfluencerManagerApp.Core.Contracts;
using InfluencerManagerApp.Models;
using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Repositories;
using InfluencerManagerApp.Repositories.Contracts;
using InfluencerManagerApp.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfluencerManagerApp.Core
{
    public class Controller : IController
    {
        private IRepository<IInfluencer> influencers;
        private IRepository<ICampaign> campaigns;

        public Controller()
        {
            this.influencers = new InfluencerRepository();
            this.campaigns = new CampaignRepository();
        }

        public string ApplicationReport()
        {
            StringBuilder sb = new StringBuilder();

            foreach (IInfluencer influencer in influencers.Models.OrderByDescending(i => i.Income).ThenByDescending(i => i.Followers))
            {
                sb.AppendLine(influencer.ToString());

                if (influencer.Participations.Count == 0)
                {
                    continue;
                }
                sb.AppendLine("Active Campaigns:");

                foreach (ICampaign campaign in campaigns.Models.Where(c => c.Contributors.Contains(influencer.Username)).OrderBy(c => c.Brand))
                {
                    sb.AppendLine($"--{campaign.ToString()}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public string AttractInfluencer(string brand, string username)
        {
            ICampaign campaign = campaigns.FindByName(brand);
            IInfluencer influencer = influencers.FindByName(username);

            if (influencer == null)
                return string.Format(OutputMessages.InfluencerNotFound, influencers.GetType().Name, username);

            if (campaign == null)
                return string.Format(OutputMessages.CampaignNotFound, brand);

            if (campaign.Contributors.Any(c => c == username))
                return string.Format(OutputMessages.InfluencerAlreadyEngaged, username, brand);

            if ((campaign.GetType().Name == nameof(ProductCampaign) && influencer.GetType().Name == nameof(BloggerInfluencer)) ||
                (campaign.GetType().Name == nameof(ServiceCampaign) && influencer.GetType().Name == nameof(FashionInfluencer)))
                return string.Format(OutputMessages.InfluencerNotEligibleForCampaign, username, brand);

            if (campaign.Budget < influencer.CalculateCampaignPrice())
                return string.Format(OutputMessages.UnsufficientBudget, brand, username);


            influencer.EarnFee(influencer.CalculateCampaignPrice());
            influencer.EnrollCampaign(campaign.Brand);
            campaign.Engage(influencer);

            return string.Format(OutputMessages.InfluencerAttractedSuccessfully, username, brand);
        }

        public string BeginCampaign(string typeName, string brand)
        {
            if (typeName != nameof(ProductCampaign) && typeName != nameof(ServiceCampaign))
                return string.Format(OutputMessages.CampaignTypeIsNotValid, typeName);

            if (campaigns.Models.Any(i => i.Brand == brand))
                return string.Format(OutputMessages.CampaignDuplicated, brand);

            ICampaign campaign;
            if (typeName == nameof(ServiceCampaign))
                campaign = new ServiceCampaign(brand);
            else
                campaign = new ProductCampaign(brand);

            campaigns.AddModel(campaign);
            return string.Format(OutputMessages.CampaignStartedSuccessfully, brand, typeName);
        }

        public string CloseCampaign(string brand)
        {
            ICampaign campaign = campaigns.FindByName(brand);

            if (campaign == null)
                return OutputMessages.InvalidCampaignToClose;

            if (campaign.Budget <= 10_000)
                return string.Format(OutputMessages.CampaignCannotBeClosed, brand);

            foreach (string influencerName in campaign.Contributors)
            {
                IInfluencer influencer = influencers.FindByName(influencerName);
                influencer.EarnFee(2000);
                influencer.EndParticipation(campaign.Brand);
            }

            campaigns.RemoveModel(campaign);
            return string.Format(OutputMessages.CampaignClosedSuccessfully, brand);

        }

        public string ConcludeAppContract(string username)
        {
            IInfluencer influencer = influencers.FindByName(username);

            if (influencer == null)
                return string.Format(OutputMessages.InfluencerNotSigned, username);

            if (influencer.Participations.Count > 0)
                return string.Format(OutputMessages.InfluencerHasActiveParticipations, username);

            influencers.RemoveModel(influencer);
            return string.Format(OutputMessages.ContractConcludedSuccessfully, username);

        }

        public string FundCampaign(string brand, double amount)
        {
            ICampaign campaign = campaigns.FindByName(brand);

            if (campaign == null)
                return OutputMessages.InvalidCampaignToFund;

            if (amount <= 0)
                return OutputMessages.NotPositiveFundingAmount;

            campaign.Gain(amount);
            return string.Format(OutputMessages.CampaignFundedSuccessfully, brand, amount);

        }

        public string RegisterInfluencer(string typeName, string username, int followers)
        {
            if (typeName != nameof(BusinessInfluencer) &&
                typeName != nameof(BloggerInfluencer) &&
                typeName != nameof(FashionInfluencer))
                return string.Format(OutputMessages.InfluencerInvalidType, typeName);

            if (influencers.Models.Any(i => i.Username == username))
                return string.Format(OutputMessages.UsernameIsRegistered, username, influencers.GetType().Name);

            IInfluencer influencer;
            if (typeName == nameof(BusinessInfluencer))
                influencer = new BusinessInfluencer(username, followers);
            else if (typeName == nameof(BloggerInfluencer))
                influencer = new BloggerInfluencer(username, followers);
            else
                influencer = new FashionInfluencer(username, followers);

            influencers.AddModel(influencer);
            return string.Format(OutputMessages.InfluencerRegisteredSuccessfully, influencer.Username);
        }
    }
}
