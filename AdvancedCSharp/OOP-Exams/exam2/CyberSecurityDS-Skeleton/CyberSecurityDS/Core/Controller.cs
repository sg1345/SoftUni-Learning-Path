using CyberSecurityDS.Core.Contracts;
using CyberSecurityDS.Models;
using CyberSecurityDS.Models.Contracts;
using CyberSecurityDS.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberSecurityDS.Core
{
    public class Controller : IController
    {
        private ISystemManager systemManager;

        public Controller()
        {
            systemManager = new SystemManager();
        }

        public string AddCyberAttack(string attackType, string attackName, int severityLevel, string extraParam)
        {
            if (systemManager.CyberAttacks.Exists(attackName))
                return string.Format(OutputMessages.EntryAlreadyExists, attackName);

            if (attackType != nameof(PhishingAttack) && attackType != nameof(MalwareAttack))
                return string.Format(OutputMessages.TypeInvalid, attackType);

            ICyberAttack newCyberAttack;
            if (attackType == nameof(PhishingAttack))
            {
                newCyberAttack = new PhishingAttack(attackName, severityLevel, extraParam);

            }
            else //if (attackType == nameof(MalwareAttack))
            {
                newCyberAttack = new MalwareAttack(attackName, severityLevel, extraParam);
            }

            systemManager.CyberAttacks.AddNew(newCyberAttack);
            return string.Format(OutputMessages.EntryAddedSuccessfully, attackType, attackName);
        }

        public string AddDefensiveSoftware(string softwareType, string softwareName, int effectiveness)
        {
            if (systemManager.DefensiveSoftwares.Exists(softwareName))
                return string.Format(OutputMessages.EntryAlreadyExists, softwareName);


            if (softwareType != nameof(Firewall) && softwareType != nameof(Antivirus))
                return string.Format(OutputMessages.TypeInvalid, softwareType);

            IDefensiveSoftware newDefensiveSoftware;
            if (softwareType == nameof(Firewall))
            {
                newDefensiveSoftware = new Firewall(softwareName, effectiveness);
            }
            else //if (softwareType == nameof(Antivirus))
            {
                newDefensiveSoftware = new Antivirus(softwareName, effectiveness);
            }

            systemManager.DefensiveSoftwares.AddNew(newDefensiveSoftware);
            return string.Format(OutputMessages.EntryAddedSuccessfully, softwareType, softwareName);
        }

        public string AssignDefense(string cyberAttackName, string defensiveSoftwareName)
        {
            if (!systemManager.CyberAttacks.Exists(cyberAttackName))
                return string.Format(OutputMessages.EntryNotFound, cyberAttackName);

            if (!systemManager.DefensiveSoftwares.Exists(defensiveSoftwareName))
                return string.Format(OutputMessages.EntryNotFound, defensiveSoftwareName);

            foreach (var currentSoftware in systemManager.DefensiveSoftwares.Models)
            {
                if (currentSoftware.AssignedAttacks.Any(a => a == cyberAttackName))
                {
                    return string.Format(OutputMessages.AttackAlreadyAssigned, cyberAttackName, currentSoftware.Name);
                }
            }

            ICyberAttack attack = systemManager.CyberAttacks.GetByName(cyberAttackName);
            IDefensiveSoftware software = systemManager.DefensiveSoftwares.GetByName(defensiveSoftwareName);

            software.AssignAttack(attack.AttackName);

            return string.Format(OutputMessages.AttackAssignedSuccessfully, attack.AttackName, defensiveSoftwareName);
        }

        public string GenerateReport()
        {
            StringBuilder report = new StringBuilder();
            report.AppendLine("Security:");
            foreach (var software in systemManager.DefensiveSoftwares.Models.OrderBy(s => s.Name))
                report.AppendLine(software.ToString());

            report.AppendLine("Threads:");

            report.AppendLine("-Mitigated:");
            foreach (var threads in systemManager.CyberAttacks.Models.Where(t => t.Status == true).OrderBy(s => s.AttackName))
                report.AppendLine(threads.ToString());

            report.AppendLine("-Pending:");
            foreach (var threads in systemManager.CyberAttacks.Models.Where(t => t.Status == false).OrderBy(s => s.AttackName))
                report.AppendLine(threads.ToString());

            return report.ToString().TrimEnd();
        }

        public string MitigateAttack(string cyberAttackName)
        {
            if (!systemManager.CyberAttacks.Exists(cyberAttackName))
                return string.Format(OutputMessages.EntryNotFound, cyberAttackName);

            ICyberAttack attack = systemManager.CyberAttacks.GetByName(cyberAttackName);

            if (attack.Status)
                return string.Format(OutputMessages.AttackAlreadyMitigated, cyberAttackName);

            bool isAssigned = false;
            foreach (var software in systemManager.DefensiveSoftwares.Models)
            {
                if (software.AssignedAttacks.Any(a => a == cyberAttackName))
                {
                    isAssigned = true;
                }
            }

            if (!isAssigned)
            {
                return string.Format(OutputMessages.AttackNotAssignedYet, cyberAttackName);
            }

            string assignedSoftware = string.Empty;
            foreach (var software in systemManager.DefensiveSoftwares.Models)
            {
                if (software.AssignedAttacks.Any(a => a == cyberAttackName))
                {
                    assignedSoftware = software.Name;
                }
            }

            IDefensiveSoftware defense = systemManager.DefensiveSoftwares.GetByName(assignedSoftware);

            Type attackType = attack.GetType();
            Type defenseType = defense.GetType();

            if (defenseType.Name == nameof(Firewall) && attackType.Name == nameof(PhishingAttack) ||
                defenseType.Name == nameof(Antivirus) && attackType.Name == nameof(MalwareAttack))
            {
                return string.Format(OutputMessages.CannotMitigateDueToCompatibility, defenseType.Name, attackType.Name);
            }

            if (defense.Effectiveness >= attack.SeverityLevel)
            {
                attack.MarkAsMitigated();
                return string.Format(OutputMessages.AttackMitigatedSuccessfully, attack.AttackName);
            }
            else// if (defense.Effectiveness < attack.SeverityLevel)
            {
                return string.Format(OutputMessages.SoftwareNotEffectiveEnough, attack.AttackName, defense.Name);
            }
        }
    }
}
