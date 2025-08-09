using HighwayToPeak.Core.Contracts;
using HighwayToPeak.Models;
using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Repositories;
using HighwayToPeak.Repositories.Contracts;
using HighwayToPeak.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighwayToPeak.Core
{
    public class Controller : IController
    {
        private IRepository<IPeak> peaks;
        private IRepository<IClimber> climbers;
        private IBaseCamp baseCamp;

        public Controller()
        {
            this.peaks = new PeakRepository();
            this.climbers = new ClimberRepository();
            this.baseCamp = new BaseCamp();
        }

        public string AddPeak(string name, int elevation, string difficultyLevel)
        {
            if (peaks.Get(name) != null)
            {
                return string.Format(OutputMessages.PeakAlreadyAdded, name);
            }

            if (difficultyLevel != "Extreme" && difficultyLevel != "Hard" && difficultyLevel != "Moderate")
            {
                return string.Format(OutputMessages.PeakDiffucultyLevelInvalid, difficultyLevel);
            }

            IPeak peak = new Peak(name, elevation, difficultyLevel);
            peaks.Add(peak);
            return string.Format(OutputMessages.PeakIsAllowed, peak.Name, peaks.GetType().Name);
        }

        public string AttackPeak(string climberName, string peakName)
        {
            if (climbers.Get(climberName) == null)
            {
                return string.Format(OutputMessages.ClimberNotArrivedYet, climberName);
            }

            if (peaks.Get(peakName) == null)
            {
                return string.Format(OutputMessages.PeakIsNotAllowed, peakName);
            }

            if (!baseCamp.Residents.Any(r=>r == climberName))
            {
                return string.Format(OutputMessages.ClimberNotFoundForInstructions, climberName, peakName);
            }

            IPeak peak = peaks.Get(peakName);
            IClimber climber = climbers.Get(climberName);

            if (peak.DifficultyLevel == "Extreme" && climber.GetType().Name == nameof(NaturalClimber))
            {
                return string.Format(OutputMessages.NotCorrespondingDifficultyLevel, climber.Name, peak.Name);
            }

            baseCamp.LeaveCamp(climber.Name);

            climber.Climb(peak);

            if (climber.Stamina == 0)
            {
                return string.Format(OutputMessages.NotSuccessfullAttack, climber.Name);
            }

            baseCamp.ArriveAtCamp(climber.Name);

            return string.Format(OutputMessages.SuccessfulAttack, climber.Name, peak.Name);
        }

        public string BaseCampReport()
        {
            StringBuilder sb = new StringBuilder();

            if (baseCamp.Residents.Count == 0)
            {
                return "BaseCamp is currently empty.";
            }

            sb.AppendLine("BaseCamp residents:");

            foreach (var climberName in baseCamp.Residents.OrderBy(c=>c))
            {
                IClimber climber = climbers.Get(climberName);
                sb.AppendLine($"Name: {climber.Name}, Stamina: {climber.Stamina}, Count of Conquered Peaks: {climber.ConqueredPeaks.Count}");
            }

            return sb.ToString().Trim();
        }

        public string CampRecovery(string climberName, int daysToRecover)
        {

            if (!baseCamp.Residents.Any(r=>r == climberName))
            {
                return string.Format(OutputMessages.ClimberIsNotAtBaseCamp, climberName);
            }

            IClimber climber = climbers.Get(climberName);

            if (climber.Stamina == 10)
            {
                return string.Format(OutputMessages.NoNeedOfRecovery, climber.Name);
            }

            climber.Rest(daysToRecover);

            return string.Format(OutputMessages.ClimberRecovered, climber.Name, daysToRecover);
        }

        public string NewClimberAtCamp(string name, bool isOxygenUsed)
        {
            if (climbers.Get(name) != null)
            {
                return string.Format(OutputMessages.ClimberCannotBeDuplicated, name, climbers.GetType().Name);
            }

            IClimber climber;
            if (isOxygenUsed)
            {
                climber = new OxygenClimber(name);
            }
            else
            {
                climber = new NaturalClimber(name);
            }

            climbers.Add(climber);
            baseCamp.ArriveAtCamp(climber.Name);

            return string.Format(OutputMessages.ClimberArrivedAtBaseCamp, name);
        }

        public string OverallStatistics()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("***Highway-To-Peak***");

            foreach (var climber in climbers.All.OrderByDescending(c=>c.ConqueredPeaks.Count).ThenBy(c=>c.Name))
            {
                sb.AppendLine(climber.ToString());                

                foreach(var peak in peaks.All.OrderByDescending(p => p.Elevation))
                {
                   foreach (var conqueredPeak in climber.ConqueredPeaks)
                    {
                        if(peak.Name == conqueredPeak)
                        {
                            sb.AppendLine(peak.ToString());
                            break;
                        }
                    }
                }
            }
                return sb.ToString().TrimEnd();   
        }
    }
}
