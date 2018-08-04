namespace TeamBuilder.Services
{
    using System.Linq;
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
    }
}