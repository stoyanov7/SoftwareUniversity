namespace _09.TeamworkProjects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TeamworkProjects
    {
        public static void Main(string[] args)
        {
            var teams = new List<Team>();

            teams = FormTeams(teams);
            teams = PopulateTeams(teams);

            var popTeams = teams
                .Where(x => x.Members.Count > 0)
                .ToList();

            var emptyTeams = teams
                .Where(x => x.Members.Count <= 0)
                .ToList();

            PrintResults(popTeams, emptyTeams);
        }

        private static List<Team> FormTeams(List<Team> teams)
        {
            var n = int.Parse(Console.ReadLine());

            for (var i = 0; i < n; i++)
            {
                var info = Console.ReadLine()
                    .Split('-')
                    .ToArray();

                var requester = info[0];
                var teamName = info[1];
                var isAllowed = true;

                if (teams.Any(x => x.Name == teamName))
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                    isAllowed = false;
                }
                else if (teams.Any(x => x.Creator == requester))
                {
                    Console.WriteLine($"{requester} cannot create another team!");
                    isAllowed = false;
                }

                if (isAllowed)
                {
                    var team = new Team(teamName, requester);
                    teams.Add(team);

                    Console.WriteLine($"Team {teamName} has been created by {requester}!");
                }
            }

            return teams;
        }

        private static List<Team> PopulateTeams(List<Team> teams)
        {
            var command = string.Empty;

            while ((command = Console.ReadLine()) != "end of assignment")
            {
                var commandTokens = command
                    .Split(new[] { '-', '>' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var requester = commandTokens[0];
                var teamReq = commandTokens[1];

                var isExistant = false;
                var isInTeam = false;

                foreach (var team in teams)
                {
                    if (team.Members.Contains(requester) || team.Creator == requester)
                    {
                        isInTeam = true;
                    }
                }

                foreach (var team in teams)
                {
                    if (team.Name == teamReq)
                    {
                        isExistant = true;
                    }

                    if (isExistant && isInTeam == false)
                    {
                        team.Members.Add(requester);
                        break;
                    }
                }

                if (isExistant == false)
                {
                    Console.WriteLine($"Team {teamReq} does not exist!");
                }
                else if (isInTeam)
                {
                    Console.WriteLine($"Member {requester} cannot join team {teamReq}!");
                }
            }

            return teams;
        }

        private static void PrintResults(List<Team> popTeams, List<Team> emptyTeams)
        {
            foreach (var team in popTeams
                .OrderByDescending(x => x.Members.Count)
                .ThenBy(z => z.Name))
            {
                Console.WriteLine(team.Name);
                Console.WriteLine($"- {team.Creator}");

                foreach (var member in team.Members.OrderBy(x => x))
                {
                    Console.WriteLine($"-- {member}");
                }
            }

            Console.WriteLine("Teams to disband:");

            foreach (var team in emptyTeams.OrderBy(x => x.Name))
            {
                Console.WriteLine(team.Name);
            }
        }
    }
}