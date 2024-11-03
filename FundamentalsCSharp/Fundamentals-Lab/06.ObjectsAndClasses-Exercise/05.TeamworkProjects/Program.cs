using Microsoft.VisualBasic;
using System.Reflection.Metadata.Ecma335;

internal class Program
{
    static void Main()
    {
        List<Teams> teams = new();

        int numberOfTeams = int.Parse(Console.ReadLine());
        int counter = 0;
        string input = string.Empty;
        while ((input = Console.ReadLine()) != "end of assignment")
        {
            string[] info = input.Split('-');

            if (info[1].Contains('>'))
            {
                info[1] = info[1].TrimStart('>');

                if (!MemberCannotJoin(teams, info) && !TeamDoesNotExist(teams, info))
                {
                    int teamIndex = IndexOfTheTeam(teams, info[1]);
                    teams[teamIndex].Members.Add(info[0]);
                }
            }
            else if (numberOfTeams != 0)
            {
                Teams newTeam = new();
                newTeam.Leader = info[0];
                newTeam.Name = info[1];

                if (!TeamExists(teams, newTeam) && !AlreadyIsLeader(teams, newTeam))
                {
                    teams.Add(newTeam);
                    teams[counter].Members = new();
                    counter++;
                    Console.WriteLine($"Team {newTeam.Name} has been created by {newTeam.Leader}!");
                }

                numberOfTeams--;
            }
        }

        teams = teams.OrderByDescending(x => x.Members.Count).ThenBy(x => x.Name).ToList();

        Print(teams);
    }

    static bool MemberCannotJoin(List<Teams> teams, string[] info)
    {
        foreach (Teams team in teams)
        {
            if (team.Members == null)
            {
                continue;
            }

            if (team.Leader == info[0])
            {
                Console.WriteLine($"Member {info[0]} cannot join team {info[1]}!");
                return true;
            }

            if (team.Members.Contains(info[0]))
            {
                Console.WriteLine($"Member {info[0]} cannot join team {info[1]}!");
                return true;
            }
        }

        return false;
    }
    static bool TeamDoesNotExist(List<Teams> teams, string[] info)
    {
        bool exists = false;
        foreach (Teams team in teams)
        {
            if (team.Name == info[1])
            {
                exists = true;
            }
        }
        if (!exists)
        {
            Console.WriteLine($"Team {info[1]} does not exist!");
            return true;
        }

        return false;
    }
    static int IndexOfTheTeam(List<Teams> teams, string teamName)
    {
        foreach (Teams team in teams)
        {
            if (team.Name == teamName)
            {
                return teams.IndexOf(team);
            }
        }

        return 0;
    }

    static bool TeamExists(List<Teams> teams, Teams newTeam)
    {
        foreach (Teams team in teams)
        {
            if (team.Name == newTeam.Name)
            {
                Console.WriteLine($"Team {team.Name} was already created!");
                return true;
            }
        }

        return false;
    }
    static bool AlreadyIsLeader(List<Teams> teams, Teams newTeam)
    {
        foreach (Teams team in teams)
        {
            if (team.Leader == newTeam.Leader)
            {
                Console.WriteLine($"{team.Leader} cannot create another team!");
                return true;
            }
        }

        return false;
    }

    static void Print(List<Teams> teams)
    {
        foreach (var team in teams)
        {
            if (team.Members.Count == 0)
            {
                continue;
            }

            team.Members = team.Members.OrderBy(x => x).ToList();

            Console.WriteLine(team.Name);
            Console.Write($"- {team.Leader}\n-- ");
            Console.WriteLine(string.Join("\n-- ", team.Members));
        }

        Console.WriteLine("Teams to disband:");

        foreach (var team in teams)
        {
            if (team.Members.Count == 0)
            {
                Console.WriteLine(team.Name);
            }
        }
    }
}

class Teams
{
    public string Leader { get; set; }
    public string Name { get; set; }
    public List<string> Members { get; set; }
}