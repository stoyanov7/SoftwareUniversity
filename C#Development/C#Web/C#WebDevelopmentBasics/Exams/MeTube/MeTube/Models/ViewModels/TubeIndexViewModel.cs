namespace MeTube.Models.ViewModels
{
    using System;

    public class TubeIndexViewModel
    {
        public string YouTubeId { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public static Func<Tube, TubeIndexViewModel> FromTube =>
            tube => new TubeIndexViewModel
            {
                YouTubeId = tube.YouTubeId,
                Title = tube.Title,
                Author = tube.Author
            };
    }
}