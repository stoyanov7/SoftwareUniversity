﻿namespace TeamBuilder.Services.Contracts
{
    using Models;

    public interface ITeamService
    {
        void CreateTeam(string name, string acronym, string description, int creatorId);

        Team GetTeam(string name);

        bool IsTeamExist(string name);

        bool IsAcronymValid(string acronym);

        bool IsMemberOfTeam(string teamName, string username);

        bool IsUserCreatorOfTeam(string teamName, User user);

        void KickMember(string teamName, string username);

        void Disband(string teamName);

        string PrintTeam(string teamName);
    }
}