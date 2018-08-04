namespace TeamBuilder.Services.Contracts
{
    public interface IUserTeamService
    {
        void CreateUserTeam(int teamId, int userId);
    }
}