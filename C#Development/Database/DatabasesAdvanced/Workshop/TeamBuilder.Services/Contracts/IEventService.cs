namespace TeamBuilder.Services.Contracts
{
    using System;

    public interface IEventService
    {
        void CreateEvent(string name, string description, DateTime startDate, DateTime endDate, int creatorId);
    }
}