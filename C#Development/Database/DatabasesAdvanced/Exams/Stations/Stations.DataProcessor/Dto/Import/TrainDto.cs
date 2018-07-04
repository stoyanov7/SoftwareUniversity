namespace Stations.DataProcessor.Dto.Import
{
    using System.ComponentModel.DataAnnotations;

    public class TrainDto
    {
        [Required]
        [MaxLength(10)]
        public string TrainNumber { get; set; }

        // Train type will always be a valid type (if not null).
        // If it’s null, use the default type (HighSpeed).
        public string Type { get; set; } = "HighSpeed";

        public SeatDto[] Seats { get; set; } = new SeatDto[0];
    }
}