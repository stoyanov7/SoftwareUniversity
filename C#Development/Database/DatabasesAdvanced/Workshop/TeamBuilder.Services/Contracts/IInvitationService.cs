namespace TeamBuilder.Services.Contracts
{
    using Models;

    public interface IInvitationService
    {
        bool IsInviteExisting(string teamName, User user);

        void CreateInvitation(User user, Team team);

        Invitation GetInvitationByTeamName(string teamName, User user);

        void DeactivateInvitation(User user, string teamName);
    }
}