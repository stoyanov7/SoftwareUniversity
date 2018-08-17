namespace MyLibrary.Models.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class AddBookViewModel
    {
        [Required(ErrorMessage = "Title is required!")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Author name is required!")]
        public AuthorViewModel Author { get; set; }

        [Required]
        [DataType(DataType.ImageUrl)]
        [Display(Name = "Image URL")]
        [Url(ErrorMessage = "Invalid URL")]
        public string ImageUrl { get; set; }
    }
}