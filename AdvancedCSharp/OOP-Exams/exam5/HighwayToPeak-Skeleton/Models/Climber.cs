using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighwayToPeak.Models
{
    public abstract class Climber : IClimber
    {
        private string name;
        private int stamina;
        private List<string> conqueredPeaks;

        protected Climber(string name, int stamina)
        {
            this.conqueredPeaks = new List<string>();
            Name = name;
            Stamina = stamina;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(ExceptionMessages.ClimberNameNullOrWhiteSpace);

                name = value;
            }
        }

        public int Stamina
        {
            get => stamina;
            protected set
            {
                if (value < 0) value = 0;
                if (value > 10) value = 10;

                stamina = value;
            }
        }

        public IReadOnlyCollection<string> ConqueredPeaks => conqueredPeaks.AsReadOnly();

        public void Climb(IPeak peak)
        {
            if (!ConqueredPeaks.Any(c => c == peak.Name))
            {
                conqueredPeaks.Add(peak.Name);
            }

            if (peak.DifficultyLevel == "Extreme")
            {
                Stamina -= 6;
            }
            else if (peak.DifficultyLevel == "Hard")
            {
                Stamina -= 4;
            }
            else if (peak.DifficultyLevel == "Moderate")
            {
                Stamina -= 2;
            }
        }

        public abstract void Rest(int daysCount);

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.GetType().Name} - Name: {Name}, Stamina: {Stamina}");

            if (ConqueredPeaks.Count > 0)
            {
                sb.AppendLine($"Peaks conquered: {ConqueredPeaks.Count}");
            }
            else
            {
                sb.AppendLine("Peaks conquered: no peaks conquered");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
