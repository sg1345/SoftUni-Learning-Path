using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheContentDepartment.Core.Contracts;
using TheContentDepartment.Models;
using TheContentDepartment.Models.Contracts;
using TheContentDepartment.Repositories;
using TheContentDepartment.Repositories.Contracts;
using TheContentDepartment.Utilities.Messages;

namespace TheContentDepartment.Core
{
    public class Controller : IController
    {
        private IRepository<IResource> resources;
        private IRepository<ITeamMember> members;

        public Controller()
        {
            this.resources = new ResourceRepository();
            this.members = new MemberRepository();
        }

        public string ApproveResource(string resourceName, bool isApprovedByTeamLead)
        {
            IResource resource = resources.TakeOne(resourceName);

            if (!resource.IsTested)
                return string.Format(OutputMessages.ResourceNotTested, resourceName);

            ITeamMember teamLeader = members.Models.FirstOrDefault(m => m.Path == "Master")!;

            if (isApprovedByTeamLead)
            {
                resource.Approve();
                teamLeader!.FinishTask(resourceName);

                return string.Format(OutputMessages.ResourceApproved, teamLeader.Name, resourceName);
            }

            resource.Test();

            return string.Format(OutputMessages.ResourceReturned, teamLeader!.Name, resourceName);
        }

        public string CreateResource(string resourceType, string resourceName, string path)
        {
            if (resourceType != nameof(Exam) && resourceType != nameof(Workshop) && resourceType != nameof(Presentation))
                return string.Format(OutputMessages.ResourceTypeInvalid, resourceType);

            if (!members.Models.Any(m => m.Path == path))
                return string.Format(OutputMessages.NoContentMemberAvailable, resourceName);

            if (members.Models.Any(m => m.InProgress.Any(cm => cm == resourceName)))
                return string.Format(OutputMessages.ResourceExists, resourceName);

            ITeamMember creater = members.Models.FirstOrDefault(m => m.Path == path);

            IResource resource;
            if (resourceType == nameof(Exam))
                resource = new Exam(resourceName, creater.Name);
            else if (resourceType == nameof(Workshop))
                resource = new Workshop(resourceName, creater.Name);
            else
                resource = new Presentation(resourceName, creater.Name);

            creater.WorkOnTask(resourceName);

            resources.Add(resource);

            return string.Format(OutputMessages.ResourceCreatedSuccessfully, creater.Name, resourceType, resourceName);
        }

        public string DepartmentReport()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Finished Tasks:");

            foreach (var resource in resources.Models.Where(r => r.IsApproved))
            {
                sb.AppendLine($"--{resource.ToString()}");
            }

            sb.AppendLine("Team Report:");

            sb.AppendLine($"--{members.Models.First(m => m.Path == "Master").ToString()}");

            foreach (var member in members.Models.Where(m => m.Path != "Master"))
            {
                sb.AppendLine(member.ToString());
            }

            return sb.ToString().TrimEnd();
        }

        public string JoinTeam(string memberType, string memberName, string path)
        {
            if (memberType != nameof(TeamLead) && memberType != nameof(ContentMember))
                return string.Format(OutputMessages.MemberTypeInvalid, memberType);

            if (members.Models.Any(m => m.Path == path))
                return OutputMessages.PositionOccupied;

            if (members.TakeOne(memberName) != null)
                return string.Format(OutputMessages.MemberExists, memberName);

            ITeamMember teamMember;

            if (memberType == nameof(TeamLead))
            {
                teamMember = new TeamLead(memberName, path);
            }
            else
            {
                teamMember = new ContentMember(memberName, path);
            }

            members.Add(teamMember);
            return string.Format(OutputMessages.MemberJoinedSuccessfully, memberName);
        }

        public string LogTesting(string memberName)
        {
            if (!members.Models.Any(m => m.Name == memberName))
                return OutputMessages.WrongMemberName;

            IResource resource = null;
            for (int i = 1; i <= 3; i++)
            {
                if (resources.Models.Where(r => r.Creator == memberName).Any(r => r.Priority == i && r.IsTested == false))
                {
                    resource = resources.Models.Where(r => r.Creator == memberName).FirstOrDefault(r => r.Priority == i && r.IsTested == false)!;
                    break;
                }
            }

            if (resource == null)
                return string.Format(OutputMessages.NoResourcesForMember, memberName);

            ITeamMember teamLead = members.Models.FirstOrDefault(m => m.Path == "Master");
            ITeamMember teamMember = members.TakeOne(memberName);

            teamMember.FinishTask(resource.Name);
            teamLead!.WorkOnTask(resource.Name);

            resource.Test();

            return string.Format(OutputMessages.ResourceTested, resource.Name);
        }
    }
}
