namespace Stations.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Enumeration;

    public class Train
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(10)]
        public string TrainNumber { get; set; }

        public TrainType? Type { get; set; }

        public virtual ICollection<TrainSeat> TrainSeats { get; set; }

        public virtual ICollection<Trip> Trips { get; set; }
    }
}