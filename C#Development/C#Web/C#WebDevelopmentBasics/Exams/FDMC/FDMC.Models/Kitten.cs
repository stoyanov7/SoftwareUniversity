namespace FDMC.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Kitten
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        public string Name { get; set; }

        [Required]
        [Range(0, 20)]
        public int Age { get; set; }

        public int BreedId { get; set; }
        public Breed Breed { get; set; }
    }
}