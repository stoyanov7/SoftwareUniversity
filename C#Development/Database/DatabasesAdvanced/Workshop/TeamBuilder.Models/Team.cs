namespace TeamBuilder.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Team
    {
        public Team()
        {
            this.EventTeams = new List<TeamEvent>();
            this.Invitations = new List<Invitation>();
            this.UserTeams = new List<UserTeam>();
        }

        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public string Description { get; set; }

        [StringLength(3, MinimumLength = 3)]
        public string Acronym { get; set; }

        public int CreatorId { get; set; }
        public User Creator { get; set; }

        public ICollection<TeamEvent> EventTeams { get; set; } 

        public ICollection<Invitation> Invitations { get; set; } 

        public ICollection<UserTeam> UserTeams { get; set; }
    }
}