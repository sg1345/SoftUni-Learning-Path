using NauticalCatchChallenge.Core.Contracts;
using NauticalCatchChallenge.Models;
using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Repositories;
using NauticalCatchChallenge.Repositories.Contracts;
using NauticalCatchChallenge.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NauticalCatchChallenge.Core
{
    public class Controller : IController
    {
        IRepository<IDiver> divers;
        IRepository<IFish> fishes;

        public Controller()
        {
            this.divers = new DiverRepository();
            this.fishes = new FishRepository();
        }

        public string ChaseFish(string diverName, string fishName, bool isLucky)
        {
            IDiver diver = divers.GetModel(diverName);
            IFish fish = fishes.GetModel(fishName);
            if (diver == null)
            {
                return string.Format(OutputMessages.DiverNotFound, divers.GetType().Name, diverName);
            }

            if (fish == null)
            {
                return string.Format(OutputMessages.FishNotAllowed, fishName);
            }

            if (diver.HasHealthIssues)
            {
                return string.Format(OutputMessages.DiverHealthCheck, diverName);
            }

            if ((diver.OxygenLevel < fish.TimeToCatch) || (diver.OxygenLevel == fish.TimeToCatch && !isLucky))
            {
                diver.Miss(fish.TimeToCatch);

                if (diver.OxygenLevel == 0)
                {
                    diver.UpdateHealthStatus();
                }

                return string.Format(OutputMessages.DiverMisses, diverName, fishName);
            }
            else //((diver.OxygenLevel > fish.TimeToCatch) || (diver.OxygenLevel == fish.TimeToCatch && isLucky))
            {
                diver.Hit(fish);

                if (diver.OxygenLevel == 0)
                {
                    diver.UpdateHealthStatus();
                }

                return string.Format(OutputMessages.DiverHitsFish, diverName, fish.Points, fishName);
            }

        }

        public string CompetitionStatistics()
        {
            StringBuilder sb = new StringBuilder();

            var competitionStatisticsReport = divers.Models
                .Where(d => !d.HasHealthIssues)
                .OrderByDescending(d => d.CompetitionPoints)
                .ThenByDescending(d => d.Catch.Count)
                .ThenBy(d => d.Name);

            sb.AppendLine("**Nautical-Catch-Challenge**");

            foreach (IDiver diver in competitionStatisticsReport) 
            {
                sb.AppendLine(diver.ToString());
            }

                return sb.ToString().TrimEnd();
        }

        public string DiveIntoCompetition(string diverType, string diverName)
        {
            if (diverType != nameof(FreeDiver) && diverType != nameof(ScubaDiver))
            {
                return string.Format(OutputMessages.DiverTypeNotPresented, diverType);
            }

            if (divers.GetModel(diverName) != null)
            {
                return string.Format(OutputMessages.DiverNameDuplication, diverName, divers.GetType().Name);
            }

            IDiver diver;
            if (diverType == nameof(ScubaDiver))
            {
                diver = new ScubaDiver(diverName);
            }
            else
            {
                diver = new FreeDiver(diverName);
            }

            divers.AddModel(diver);

            return string.Format(OutputMessages.DiverRegistered, diverName, divers.GetType().Name);

        }

        public string DiverCatchReport(string diverName)
        {
            IDiver diver = divers.GetModel(diverName);
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine(diver.ToString());
            stringBuilder.AppendLine("Catch Report:");

            foreach (string catchedFish in diver.Catch)
            {
                IFish fish = fishes.GetModel(catchedFish);

                stringBuilder.AppendLine(fish.ToString());
            }

            return stringBuilder.ToString().TrimEnd();
        }

        public string HealthRecovery()
        {
            int countDiversRecovered = 0;

            foreach (var diver in divers.Models)
            {
                if (diver.HasHealthIssues)
                {
                    diver.UpdateHealthStatus();
                    diver.RenewOxy();
                    countDiversRecovered++;
                }
            }
            return string.Format(OutputMessages.DiversRecovered, countDiversRecovered);

        }

        public string SwimIntoCompetition(string fishType, string fishName, double points)
        {
            if (fishType != nameof(ReefFish) && fishType != nameof(DeepSeaFish) && fishType != nameof(PredatoryFish))
            {
                return string.Format(OutputMessages.FishTypeNotPresented, fishType);
            }

            if (fishes.GetModel(fishName) != null)
            {
                return string.Format(OutputMessages.FishNameDuplication, fishName, fishes.GetType().Name);
            }

            IFish fish;
            if (fishType == nameof(ReefFish))
            {
                fish = new ReefFish(fishName, points);
            }
            else if (fishType == nameof(DeepSeaFish))
            {
                fish = new DeepSeaFish(fishName, points);
            }
            else
            {
                fish = new PredatoryFish(fishName, points);
            }

            fishes.AddModel(fish);

            return string.Format(OutputMessages.FishCreated, fishName);
        }
    }
}
