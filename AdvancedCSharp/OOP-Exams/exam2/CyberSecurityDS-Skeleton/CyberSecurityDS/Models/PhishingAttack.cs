using CyberSecurityDS.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberSecurityDS.Models
{
    public class PhishingAttack : CyberAttack
    {
        private string targetMail;

        public string TargetMail
        {
            get { return targetMail; }

            private set 
            { 
                if(string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(ExceptionMessages.TargetMailRequired);

                targetMail = value;
            }
        }

        public PhishingAttack(string attackName, int severityLevel, string targetMail) : base(attackName, severityLevel)
        {
            this.TargetMail = targetMail;
        }

        public override string ToString()
        {
            return $"Attack: {AttackName}, Severity: {SeverityLevel} (Target Mail: {TargetMail})";
        }
    }
}
