namespace TeamBuilder.Services.Contracts
{
    using System;
    using Models;

    public interface IEventService
    {
        void CreateEvent(string name, string description, DateTime startDate, DateTime endDate, int creatorId);

        bool IsEventExist(string eventName);

        bool IsUserCreatorOfEvent(string eventName, User user);

        bool IsTeamInEvent(string eventName, string teamName);

        void AddTeamToEvent(string teamName, string eventName);

        string PrintEvent(string eventName);
    }
}