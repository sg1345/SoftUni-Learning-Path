using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorsAndComparators
{
    public class Library : IEnumerable<Book>, IComparer<Book>
    {

        public Library(params Book[] books)
        {
            Books = new List<Book>(books);
            Books.Sort();
        }

        public List<Book> Books { get; }

        public IEnumerator<Book> GetEnumerator()
            => new LibraryIterator(Books);

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();

        public int Compare(Book? x, Book? y)
        {
            int result = x.Title.CompareTo(y.Title);
            if (result == 0)
            {
                result = y.Year.CompareTo(x.Year);
            }
            return result;
        }

        public int Count => Books.Count;

        private class LibraryIterator : IEnumerator<Book>
        {
            private readonly List<Book> books;
            private int currentIndex;

            public LibraryIterator(List<Book> books)
            {
                this.books = new List<Book>(books);
                Reset();
            }

            public Book Current => books[currentIndex];
            object IEnumerator.Current => Current;

            public bool MoveNext()
            {
                if (currentIndex == books.Count) return false;
                return ++currentIndex < books.Count;
            }

            public void Reset() => currentIndex = -1;
            public void Dispose() { }
        }
    }
}
