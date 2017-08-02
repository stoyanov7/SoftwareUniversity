namespace _02.BookShop
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var author = Console.ReadLine();
            var title = Console.ReadLine();
            var price = decimal.Parse(Console.ReadLine());

            try
            {
                var book = new Book(author, title, price);
                var goldenEditionBook = new GoldenEditionBook(author, title, price);

                Console.WriteLine(book.ToString());
                Console.WriteLine(goldenEditionBook.ToString());
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }
    }
}
