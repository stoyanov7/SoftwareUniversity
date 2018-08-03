namespace TeamBuilder.Models
{
    using System;
    using System.Collections.Generic;

    public class Event
    {
        public Event()
        {
            this.ParticipatingEventTeams = new List<TeamEvent>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate{ get; set; }

        public int CreatorId{ get; set; }
        public User Creator { get; set; }

        public ICollection<TeamEvent> ParticipatingEventTeams { get; set; }
    }
}