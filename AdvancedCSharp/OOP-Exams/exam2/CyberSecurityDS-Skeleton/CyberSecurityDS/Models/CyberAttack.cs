using CyberSecurityDS.Models.Contracts;
using CyberSecurityDS.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberSecurityDS.Models
{
    public abstract class CyberAttack : ICyberAttack
    {
        private string attackName;
        private int severityLevel;
        private bool status;

        public CyberAttack(string attackName, int severityLevel)
        {
            AttackName = attackName;
            SeverityLevel = severityLevel;
            status = false;
        }

        public string AttackName
        {
            get
            { return attackName; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(ExceptionMessages.CyberAttackNameRequired);

                attackName = value;
            }
        }

        public int SeverityLevel
        {
            get
            { return severityLevel; }

            private set
            {
                if (value < 0)
                    throw new ArgumentException(ExceptionMessages.SeverityLevelNegative);

                if (value == 0) value = 1;
                if (value > 10) value = 10;

                severityLevel = value;
            }
        }

        public bool Status
        {
            get { return status; }
        }

        public void MarkAsMitigated()
        {
            if(!status)
            status = true;
        }
    }
}
