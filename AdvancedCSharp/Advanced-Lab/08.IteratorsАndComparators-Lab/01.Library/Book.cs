using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorsAndComparators
{
    public class Book
    {
        private string? _title;
        private int _year;
        private IReadOnlyList<string>? _authors;

        public Book(string title, int year, params string[] authors)
        {
            this.Title = title;
            this.Year = year;
            this.Authors = authors;
        }

        public string Title { get => this._title!; set => this._title = value; }
        public int Year { get => this._year; set => this._year = value; }
        public IReadOnlyList<string> Authors 
        { 
            get => this._authors!; set => this._authors = value;
        }

        public override string ToString()
        {
            return $"Title: {this.Title} Year:{this.Year} AuthersCount:{this.Authors.Count}"; 
        }
    }
}
