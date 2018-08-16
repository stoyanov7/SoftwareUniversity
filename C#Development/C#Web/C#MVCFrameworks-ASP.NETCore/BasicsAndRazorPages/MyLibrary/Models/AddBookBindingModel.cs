namespace MyLibrary.Models
{
    using System.ComponentModel.DataAnnotations;

    public class AddBookBindingModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public Author Author { get; set; }

        [Required]
        [DataType(DataType.ImageUrl)]
        [Display(Name = "Image URL")]
        [Url(ErrorMessage = "Invalid URL")]
        public string ImageUrl { get; set; }
    }
}