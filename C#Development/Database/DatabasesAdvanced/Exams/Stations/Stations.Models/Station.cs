namespace Stations.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Station
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Town { get; set; }

        public virtual ICollection<Trip> TripsTo { get; set; } 

        public virtual ICollection<Trip> TripsFrom { get; set; } 
    }
}
