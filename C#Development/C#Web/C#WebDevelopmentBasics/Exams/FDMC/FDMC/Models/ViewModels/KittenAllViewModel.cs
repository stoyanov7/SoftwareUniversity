namespace FDMC.Models.ViewModels
{
    using System;
    using System.Linq.Expressions;

    public class KittenAllViewModel
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public string Breed { get; set; }

        public string PictureUrl { get; set; } = "https://www.catster.com/wp-content/uploads/2017/12/A-kitten-meowing.jpg";

        public static Expression<Func<Kitten, KittenAllViewModel>> FromKitten =>
            k => new KittenAllViewModel
            {
                Name = k.Name,
                Age = k.Age,
                Breed = k.Breed.Name
            };
    }
}