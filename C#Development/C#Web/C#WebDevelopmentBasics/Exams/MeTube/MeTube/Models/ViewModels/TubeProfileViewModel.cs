namespace MeTube.Models.ViewModels
{
    using System;

    public class TubeProfileViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public static Func<Tube, TubeProfileViewModel> FromTube =>
            tube => new TubeProfileViewModel
            {
                Id = tube.Id,
                Title = tube.Title,
                Author = tube.Author
            };
    }
}