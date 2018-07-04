namespace Stations.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Enumeration;

    public class Trip
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int OriginStationId { get; set; }
        [Required]
        public Station OriginStation { get; set; }

        [Required]
        public int DestinationStationId { get; set; }
        [Required]
        public Station DestinationStation { get; set; }

        [Required]
        public DateTime DepartureTime { get; set; }

        [Required]
        public DateTime ArrivalTime { get; set; }

        [Required]
        public int TrainId { get; set; }
        [Required]
        public Train Train { get; set; }

        public TripStatus Status { get; set; }

        public TimeSpan? TimeDifference { get; set; }
    }
}