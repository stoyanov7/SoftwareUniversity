namespace BookShop.Initializer.Generators
{
    using System.Collections.Generic;
    using System.Linq;
    using Models;

    public static class CategoryGenerator
    {
        public static List<Category> CreateCategories()
        {
            var categoryNames = new[]
            {
                "Science Fiction",
                "Drama",
                "Action",
                "Adventure",
                "Romance",
                "Mystery",
                "Horror",
                "Health",
                "Travel",
                "Children's",
                "Science",
                "History",
                "Poetry",
                "Comics",
                "Art",
                "Cookbooks",
                "Journals",
                "Biographies",
                "Fantasy",
            };

            return categoryNames
                .Select(t => new Category {Name = t})
                .ToList();
        }
    }
}