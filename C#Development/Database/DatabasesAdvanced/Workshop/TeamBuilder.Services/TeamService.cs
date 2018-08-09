namespace TeamBuilder.Services
{
    using System.Linq;
    using System.Text;
    using Contracts;
    using Data;
    using Models;

    public class TeamService : ITeamService
    {
        private readonly TeamBuilderContext context;

        public TeamService(TeamBuilderContext context) => this.context = context;

        public void CreateTeam(string name, string acronym, string description, int creatorId)
        {
            var team = new Team
            {
                Name = name,
                Acronym = acronym,
                Description = description,
                CreatorId = creatorId
            };

            this.context.Teams.Add(team);
            this.context.SaveChanges();
        }

        public Team GetTeam(string name)
        {
            return this.context
                .Teams
                .SingleOrDefault(t => t.Name.ToLower() == name.ToLower());
        }

        public bool IsTeamExist(string name)
        {
            return this.context
                .Teams
                .Any(t => t.Name.ToLower() == name.ToLower());
        }

        public bool IsAcronymValid(string acronym) => acronym.Length == 3;

        public bool IsMemberOfTeam(string teamName, string username)
        {
            return this.context
                .Teams
                .Single(t => t.Name == teamName)
                .UserTeams
                .Any(ut => ut.User.Username == username);
        }

        public bool IsUserCreatorOfTeam(string teamName, User user)
        {
            return this.context
                .Teams
                .SingleOrDefault(t => t.Name == teamName)
                .CreatorId
                .Equals(user.Id);
        }

        public void KickMember(string teamName, string username)
        {
            var team = this.GetTeam(teamName);

            var member = team
                .UserTeams
                .FirstOrDefault(m => m.Team.Name == teamName && 
                                     m.User.Username == username);

            team.UserTeams.Remove(member);
            this.context.SaveChanges();
        }

        public void Disband(string teamName)
        {
            var team = this.context
                .Teams
                .SingleOrDefault(t => t.Name == teamName);

            this.context.Teams.Remove(team);
            this.context.SaveChanges();
        }

        public string PrintTeam(string teamName)
        {
            var team = this.context
                .Teams
                .SingleOrDefault(t => t.Name == teamName);

            var sb = new StringBuilder();
            sb.AppendLine($"{teamName} {team.Acronym}")
                .AppendLine("Members:");

            foreach (var member in team.UserTeams)
            {
                sb.AppendLine($"--{member.User.Username}");
            }

            var result = sb.ToString().TrimEnd();
            return result;
        }
    }
}