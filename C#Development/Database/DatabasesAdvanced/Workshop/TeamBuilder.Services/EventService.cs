namespace TeamBuilder.Services
{
    using System;
    using System.Linq;
    using System.Text;
    using Contracts;
    using Data;
    using Models;

    public class EventService : IEventService
    {
        private readonly TeamBuilderContext context;

        public EventService(TeamBuilderContext context) => this.context = context;

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

        public bool IsEventExist(string eventName)
        {
            return this.context
                .Events
                .Any(e => e.Name == eventName);
        }

        public bool IsUserCreatorOfEvent(string eventName, User user)
        {
            return this.context
                .Events
                .FirstOrDefault(e => e.Name == eventName)
                .CreatorId
                .Equals(user.Id);
        }

        public bool IsTeamInEvent(string eventName, string teamName)
        {
            return this.context
                .Events
                .FirstOrDefault(e => e.Name == eventName)
                .ParticipatingEventTeams
                .Any(t => t.Team.Name == teamName);
        }

        public void AddTeamToEvent(string teamName, string eventName)
        {
            var team = this.context
                .Teams
                .SingleOrDefault(t => t.Name == teamName);

            var currentEvent = this.context
                .Events
                .FirstOrDefault(e => e.Name == eventName);

            var teamEvent = new TeamEvent
            {
                TeamId = team.Id,
                EventId = currentEvent.Id
            };

            currentEvent.ParticipatingEventTeams.Add(teamEvent);
            this.context.SaveChanges();
        }

        public string PrintEvent(string eventName)
        {
            var currentEvent = this.context
                .Events
                .FirstOrDefault(e => e.Name == eventName);

            var sb = new StringBuilder();
            sb.AppendLine($"{eventName} {currentEvent?.StartDate} {currentEvent?.EndDate}")
                .AppendLine($"{currentEvent?.Description}")
                .AppendLine("Teams:");
            
            foreach (var team in currentEvent.ParticipatingEventTeams)
            {
                sb.AppendLine($"-{team.Team.Name}");
            }

            var result = sb.ToString().TrimEnd();
            return result;
        }
    }
}