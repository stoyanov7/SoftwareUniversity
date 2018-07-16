namespace BookShop.Initializer.Generators
{
    using System.Collections.Generic;
    using System.Linq;
    using Models;

    public static class AuthorGenerator
    {
        public static List<Author> CreateAuthors()
        {
            var authorNames = new[]
            {
                "Nayden Vitanov",
                "Deyan Tanev",
                "Desislav Petkov",
                "Dyakon Hristov",
                "Milen Todorov",
                "Aleksander Kishishev",
                "Ilian Stoev",
                "Milen Balkanski",
                "Kostadin Nakov",
                "Petar Strashilov",
                "Bozhidara Valova",
                "Lyubina Kostova",
                "Radka Antonova",
                "Vladimira Blagoeva",
                "Bozhidara Rysinova",
                "Borislava Dimitrova",
                "Anelia Velichkova",
                "Violeta Kochanova",
                "Lyubov Ivanova",
                "Blagorodna Dineva",
                "Desislav Bachev",
                "Mihael Borisov",
                "Ventsislav Petrova",
                "Hristo Kirilov",
                "Penko Dachev",
                "Nikolai Zhelyaskov",
                "Petar Tsvetanov",
                "Spas Dimitrov",
                "Stanko Popov",
                "Miro Kochanov",
                "Pesho Stamatov",
                "Roger Porter",
                "Jeffrey Snyder",
                "Louis Coleman",
                "George Powell",
                "Jane Ortiz",
                "Randy Morales",
                "Lisa Davis",

            };

            return authorNames
                .Select(t => t.Split())
                .Select(tokens => new Author(tokens[0], tokens[1]))
                .ToList();
        }
    }
}