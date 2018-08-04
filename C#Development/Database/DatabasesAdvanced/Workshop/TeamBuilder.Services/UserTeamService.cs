namespace TeamBuilder.Services
{
    using Contracts;
    using Data;
    using Models;

    public class UserTeamService : IUserTeamService
    {
        private readonly TeamBuilderContext context;

        public UserTeamService(TeamBuilderContext context)
        {
            this.context = context;
        }

        public void CreateUserTeam(int teamId, int userId)
        {
            var userTeam = new UserTeam
            {
                TeamId = teamId,
                UserId = userId
            };

            this.context.UserTeams.Add(userTeam);
            this.context.SaveChanges();
        }
    }
}