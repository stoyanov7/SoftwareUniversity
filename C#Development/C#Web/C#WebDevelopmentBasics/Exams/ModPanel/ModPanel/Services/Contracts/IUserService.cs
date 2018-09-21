namespace ModPanel.Services.Contracts
{
    using System.Collections.Generic;
    using Models.Enums;
    using Models.ViewModels;

    public interface IUserService
    {
        bool Create(string email, string password, PositionType position);

        bool UserIsApproved(string email);

        bool UserExists(string email, string password);

        IEnumerable<AdminUsersViewModel> All();

        string Approve(int id);
    }
}