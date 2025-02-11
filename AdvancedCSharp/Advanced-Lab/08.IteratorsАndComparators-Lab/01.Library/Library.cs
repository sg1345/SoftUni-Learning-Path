using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorsAndComparators
{
    public class Library //: IEnumerable<Book>
    {
        private List<Book>? books;

        public Library(params Book[] books)
        {
            this.Books = new(books);
        }

        public List<Book> Books { get => books!; set => books = value; }

       // public IEnumerator<Book> GetEnumerator()
      //  {
       //     throw new NotImplementedException();
      //  }

        //IEnumerator IEnumerable.GetEnumerator()
               // => GetEnumerator();
    }
}
