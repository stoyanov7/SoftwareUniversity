namespace Library
{
    using System.Collections;
    using System.Collections.Generic;

    public class Library : IEnumerable<Book>
    {
        private readonly SortedSet<Book> books;

        public Library(params Book[] books)
        {
            this.books = new SortedSet<Book>(books);
        }

        private class LibraryIterator : IEnumerator<Book>
        {
            private readonly List<Book> books;
            private int index;

            public LibraryIterator(IEnumerable<Book> books)
            {
                this.Reset();
                this.books = new List<Book>(books);
            }

            public Book Current => this.books[this.index];

            object IEnumerator.Current => this.Current;

            public bool MoveNext() => ++this.index < this.books.Count;

            public void Reset() => this.index = -1;

            public void Dispose() { }
        }

        public IEnumerator<Book> GetEnumerator() => new LibraryIterator(this.books);

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}