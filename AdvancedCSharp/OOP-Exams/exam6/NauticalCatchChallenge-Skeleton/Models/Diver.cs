using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NauticalCatchChallenge.Models
{
    public abstract class Diver : IDiver
    {
        private string name;
        private int oxygenLevel;
        private double competitionPoints; // 0
        private bool hasHealthIssues; // false
        private List<string> _catch;

        protected Diver( string name, int oxygenLevel)
        {
            _catch = new List<string>();
            Name = name;
            OxygenLevel = oxygenLevel;
            CompetitionPoints = 0;
            HasHealthIssues = false;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(ExceptionMessages.DiversNameNull);

                name = value;
            }
        }

        public int OxygenLevel
        {
            get => oxygenLevel;
            protected set
            {
                if (value < 0)
                    value = 0;

                oxygenLevel = value;
            }
        }


        public double CompetitionPoints
        {
            get => Math.Round(competitionPoints, 1);
            private set
            {
                competitionPoints = value;
            }
        }

        public bool HasHealthIssues
        {
            get => hasHealthIssues;
            private set
            {
                hasHealthIssues = value;
            }
        }
        public IReadOnlyCollection<string> Catch => _catch.AsReadOnly();

        public void Hit(IFish fish)
        {
            OxygenLevel -= fish.TimeToCatch;
            _catch.Add(fish.Name);
            CompetitionPoints += fish.Points;
        }

        public abstract void Miss(int TimeToCatch);

        public abstract void RenewOxy();

        public void UpdateHealthStatus()
        {
            HasHealthIssues = !HasHealthIssues;
        }

        public override string ToString()
        {
            return $"Diver [ Name: {Name}, Oxygen left: {OxygenLevel}, Fish caught: {Catch.Count}, Points earned: {CompetitionPoints} ]";
        }
    }
}
