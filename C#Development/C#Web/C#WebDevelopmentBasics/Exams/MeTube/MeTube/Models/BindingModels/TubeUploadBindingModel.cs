namespace MeTube.Models.BindingModels
{
    using System.ComponentModel.DataAnnotations;

    public class TubeUploadBindingModel
    {
        [Required]
        [MinLength(3)]
        public string Title { get; set; }

        [Required]
        [MinLength(3)]
        public string Author { get; set; }

        [Required]
        [DataType(DataType.Url)]
        public string YouTubeLink { get; set; }

        public string Description { get; set; }
    }
}