using System.Globalization;

namespace BookShop
{
    using Models.Enums;
    using Data;
    using Initializer;
    using System.Text;
    using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
    using BookShop.Models;
    using Microsoft.EntityFrameworkCore;

    public class StartUp
    {

        public static void Main()
        {
            using var db = new BookShopContext();
            //DbInitializer.ResetDatabase(db);

            //int command = int.Parse(Console.ReadLine()!);
            //string command = Console.ReadLine()!;
            //Console.WriteLine(CountBooks(db, command));
            Console.WriteLine(RemoveBooks(db));
            Console.WriteLine();
        }

        //Problem 2
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            StringBuilder sb = new StringBuilder();

            if (Enum.TryParse<AgeRestriction>(command, true, out var ageRestriction))
            {
                int enumAge = (int)ageRestriction;
                var books = context.Books
                    .AsNoTracking()
                    .Where(b => b.AgeRestriction == ageRestriction)
                    .Select(b => new
                    {
                        b.Title
                    })
                    .OrderBy(b => b.Title)
                    .ToArray();

                foreach (var book in books)
                {
                    sb.AppendLine(book.Title);
                }

                return sb.ToString().TrimEnd();
            }


            return string.Empty;
        }

        //Problem 3
        public static string GetGoldenBooks(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var books = context.Books
                .AsNoTracking()
                .Where(b => b.EditionType == EditionType.Gold && b.Copies < 5000)
                .OrderBy(b => b.BookId)
                .Select(b => new
                {
                    b.Title
                })
                .ToArray();

            foreach (var book in books)
            {
                sb.AppendLine(book.Title);
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 4
        public static string GetBooksByPrice(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var books = context.Books
                .AsNoTracking()
                .Where(b => b.Price > 40)
                .Select(b => new
                {
                    b.Title,
                    b.Price
                })
                .OrderByDescending(b => b.Price)
                .ToArray();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - ${book.Price:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 5
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            StringBuilder sb = new StringBuilder();

            var books = context.Books
                .AsNoTracking()
                .Where(b => b.ReleaseDate == null || b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => new
                {
                    b.Title
                })
                .ToArray();

            foreach (var book in books)
            {
                sb.AppendLine(book.Title);
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 6
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            StringBuilder sb = new StringBuilder();
            string[] categories = input.ToLower().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var books = context.Books
                .AsNoTracking()
                .Include(b => b.BookCategories)
                .ThenInclude(bc => bc.Category)
                .Select(e => new
                {
                    BookTitle = e.Title,
                    BookCategories = e.BookCategories
                        .Select(bc => bc.Category.Name.ToLower())
                        .ToArray()
                })
                .Where(b => b.BookCategories.Any(c => categories.Contains(c)))
                .OrderBy(b => b.BookTitle)
                .ToArray();

            foreach (var book in books)
            {
                sb.AppendLine(book.BookTitle);
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 7
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            StringBuilder sb = new StringBuilder();

            DateTime inputDateTime = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var books = context.Books
                .AsNoTracking()
                .Where(b =>
                    b.ReleaseDate < inputDateTime)
                .OrderByDescending(b => b.ReleaseDate)
                .Select(b => new
                {
                    b.Title,
                    b.EditionType,
                    b.Price,
                })
                .ToArray();


            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price:f2}");
            }

            return sb.ToString().TrimEnd();

        }

        //Problem 8
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            StringBuilder sb = new StringBuilder();

            var authors = context.Authors
                .AsNoTracking()
                .Where(a => a.FirstName != null && a.FirstName.EndsWith(input))
                .Select(a => new
                {
                    a.FirstName,
                    a.LastName
                })
                .OrderBy(a => a.FirstName)
                .ThenBy(a => a.LastName)
                .ToArray();

            foreach (var author in authors)
            {
                sb.AppendLine($"{author.FirstName} {author.LastName}");
            }
            return sb.ToString().TrimEnd();
        }

        //Problem 9
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            StringBuilder sb = new StringBuilder();

            var books = context
                .Books
                .AsNoTracking()
                .Where(b => !b.Equals(null) && b.Title.ToLower().Contains(input.ToLower()))
                .Select(b => new
                {
                    b.Title
                })
                .OrderBy(b => b.Title)
                .ToArray();

            foreach (var book in books)
            {
                sb.AppendLine(book.Title);
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 10
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            StringBuilder sb = new StringBuilder();

            var authors = context
                .Authors
                .AsNoTracking()
                .Where(a => a.LastName.ToLower().StartsWith(input.ToLower()))
                .OrderBy(a => a.AuthorId)
                .Select(a => new
                {
                    AuthorFullName = a.FirstName + " " + a.LastName,
                    Books = a.Books
                            .Select(b => new
                            {
                                b.Title,
                                b.BookId
                            })
                        .OrderBy(b => b.BookId)
                        .ToArray()
                })
                .ToArray();

            foreach (var author in authors)
            {
                foreach (var book in author.Books)
                {
                    sb.AppendLine($"{book.Title} ({author.AuthorFullName})");
                }
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 11
        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            return context
                .Books
                .AsNoTracking()
                .Count(b => b.Title.Length > lengthCheck);
        }

        //Problem 12
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var authors = context
                .Authors
                .AsNoTracking()
                .Select(a => new
                {
                    TotalCopies = a.Books.Sum(b => b.Copies),
                    AuthorFullName = a.FirstName + " " + a.LastName
                })
                .OrderByDescending(a => a.TotalCopies)
                .ToArray();

            foreach (var author in authors)
            {
                sb.AppendLine($"{author.AuthorFullName} - {author.TotalCopies}");
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 13
        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var booksByCategory = context
                .Categories
                .AsNoTracking()
                .Select(c => new
                {
                    CategoryName = c.Name,
                    TotalProfit = c.CategoryBooks.Sum(cb => cb.Book.Copies * cb.Book.Price)
                })
                .OrderByDescending(c => c.TotalProfit)
                .ThenBy(c => c.CategoryName)
                .ToArray();

            foreach (var category in booksByCategory)
            {
                sb.AppendLine($"{category.CategoryName} ${category.TotalProfit:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 14
        public static string GetMostRecentBooks(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var mostRecentBooks = context
                .Categories
                .AsNoTracking()
                .Select(c => new
                {
                    CategoryName = c.Name,
                    RecentBooks = c.CategoryBooks
                        .Select(cb => new
                        {
                            cb.Book.Title,
                            cb.Book.ReleaseDate
                        })
                        .OrderByDescending(b => b.ReleaseDate)
                        .Take(3)
                        .ToArray()
                })
                .OrderBy(c => c.CategoryName)
                .ToArray();

            foreach (var category in mostRecentBooks)
            {
                sb.AppendLine($"--{category.CategoryName}");

                foreach (var book in category.RecentBooks)
                {
                    sb.AppendLine($"{book.Title} ({book.ReleaseDate?.Year})");
                }
            }
            return sb.ToString().TrimEnd();
        }

        //Problem 15
        public static void IncreasePrices(BookShopContext context) 
        {
            var booksToUpdate = context
                .Books               
                .Where(b => b.ReleaseDate != null && b.ReleaseDate.Value.Year < 2010)
                .ToArray();

            foreach (var book in booksToUpdate)
            {
                book.Price += 5;
            }

            context.Books.UpdateRange(booksToUpdate);
            context.SaveChanges();
        }

        //Problem 16
        public static int RemoveBooks(BookShopContext context)
        {
            var booksToRemove = context
                .Books
                .Where(b=> b.Copies <4200)
                .ToArray();

            int removedBooksCount = booksToRemove.Length;

            context.Books.RemoveRange(booksToRemove);
            context.SaveChanges();

            return removedBooksCount;
        }

    }
}


