using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorsAndComparators
{
    public class Book
    {

        public Book(string title, int year, params string[] authors)
        {
            this.Title = title;
            this.Year = year;
            this.Authors = new(authors);
        }

        public string Title { get;}
        public int Year { get; }
        public List<string> Authors { get; }
    }
}
