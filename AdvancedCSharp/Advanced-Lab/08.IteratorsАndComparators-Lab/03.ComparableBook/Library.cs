using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorsAndComparators
{
    public class Library : IEnumerable<Book>
    {       

        public Library(params Book[] books)
        {
            this.Books = new List<Book>(books);            
        }

        public List<Book> Books { get; }

        public IEnumerator<Book> GetEnumerator()
            => new LibraryIterator(this.Books);

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();


        public int Count => this.Books.Count;

        private class LibraryIterator : IEnumerator<Book>
        {
            private readonly List<Book> books;
            private int currentIndex;

            public LibraryIterator(List<Book> books)
            {
                this.books = new List<Book>(books);
                this.Reset();
            }

            public Book Current => this.books[this.currentIndex];
            object IEnumerator.Current => this.Current;

            public bool MoveNext()
            {
                if (this.currentIndex == this.books.Count) return false;
                return ++this.currentIndex < books.Count;
            }

            public void Reset() => this.currentIndex = -1;
            public void Dispose() { }
        }
    }
}
