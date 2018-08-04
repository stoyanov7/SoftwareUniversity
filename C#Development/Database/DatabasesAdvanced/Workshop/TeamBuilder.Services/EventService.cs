namespace TeamBuilder.Services
{
    using System;
    using Contracts;
    using Data;
    using Models;

    public class EventService : IEventService
    {
        private readonly TeamBuilderContext context;

        public EventService(TeamBuilderContext context)
        {
            this.context = context;
        }

        public void CreateEvent(string name, string description, DateTime startDate, DateTime endDate, int creatorId)
        {
            var newEvent = new Event
            {
                Name = name,
                Description = description,
                StartDate = startDate,
                EndDate = endDate,
                CreatorId = creatorId
            };

            this.context.Events.Add(newEvent);
            this.context.SaveChanges();
        }
    }
}