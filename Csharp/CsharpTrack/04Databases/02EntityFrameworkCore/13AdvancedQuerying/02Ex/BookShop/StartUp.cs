using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using BookShop.Models.Enums;

namespace BookShop
{
    using Data;
    using Initializer;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            DbInitializer.ResetDatabase(db);



            int result = RemoveBooks(db);

            Console.WriteLine(result);

        }

        public static int RemoveBooks(BookShopContext context)
        {
            var query = context.Books.Where(b => b.Copies < 4200);

            int count = query.Count();

            context.Books.RemoveRange(query);

            context.SaveChanges();

            return count;

        }

        public static void IncreasePrices(BookShopContext context)
        {
            int year = 2010;

            var booksBefore = context.Books.Where(b => b.ReleaseDate.Value.Year < year);

            foreach (var book in booksBefore)
            {
                book.Price += 5;
            }

            context.SaveChanges();
        }

        public static string GetMostRecentBooks(BookShopContext context)
        {
            var toReturn = context.Categories
                .OrderBy(c => c.Name)
                .Select(c => new
                {
                    catName = c.Name,
                    books = c.CategoryBooks.Select(b => new
                    {
                        bookName = b.Book.Title,
                        releaseDate = b.Book.ReleaseDate
                    }).OrderByDescending(b => b.releaseDate.Value).Take(3).ToList()
                }).ToList();

            StringBuilder sb = new StringBuilder();
            foreach (var cat in toReturn)
            {

                sb.AppendLine($"--{cat.catName}");

                foreach (var book in cat.books)
                {
                    sb.AppendLine($"{book.bookName} ({book.releaseDate.Value.Year})");
                }

            }

            return sb.ToString().TrimEnd();

        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var profitReport = context.Categories.Select(c => new
            {
                name = c.Name,
                profit = c.CategoryBooks
                    .Sum(b => b.Book.Copies * b.Book.Price)
            })
                .OrderByDescending(c => c.profit)
                .ToList();

            StringBuilder sb = new StringBuilder();


            foreach (var prof in profitReport)
            {
                sb.AppendLine($"{prof.name} ${prof.profit:f2}");
            }

            return sb.ToString().TrimEnd();

        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var book = context.Authors.Select(a => new
            {
                name = a.FirstName + " " + a.LastName,
                count = a.Books.Sum(b => b.Copies)
            }).ToList().OrderByDescending(b => b.count);

            StringBuilder sb = new StringBuilder();

            foreach (var athr in book)
            {
                sb.AppendLine($"{athr.name} - {athr.count}");
            }

            return sb.ToString().TrimEnd();

        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            int count = context.Books.Where(b => b.Title.Length > lengthCheck).Select(b => b.Title).Count();

            return count;
        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var books = context
                .Books
                .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .Select(b => new
                {
                    name = b.Title,
                    author = b.Author.FirstName + " " + b.Author.LastName,
                    id = b.BookId
                })
                .OrderBy(d => d.id)
                .ToList();

            StringBuilder sb = new StringBuilder();


            foreach (var book in books)
            {
                sb.AppendLine($"{book.name} ({book.author})");

            }

            return sb.ToString().TrimEnd();


        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var books = context
                .Books.Where(b => b.Title.ToLower().Contains(input.ToLower()))
                .Select(b => b.Title)
                .ToList()
                .OrderBy(b => b);

            StringBuilder sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine(book);
            }

            return sb.ToString().TrimEnd();


        }


        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {

            var authors = context.Authors
                .Where(a => a.FirstName.EndsWith(input))
                .Select(a => $"{a.FirstName} {a.LastName}")
                .ToArray()
                .OrderBy(b => b);


            StringBuilder sb = new StringBuilder();
            foreach (var author in authors)
            {
                sb.AppendLine(author);
            }


            return sb.ToString().TrimEnd();
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            DateTime limitDate = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var booksBefore = context
                .Books
                .Where(b => b.ReleaseDate.Value < limitDate)
                .Select(b => new
                {
                    name = b.Title,
                    price = b.Price,
                    edintion = b.EditionType.ToString(),
                    date = b.ReleaseDate.Value

                }).ToList().OrderByDescending(b => b.date);

            StringBuilder sb = new StringBuilder();

            foreach (var book in booksBefore)
            {
                sb.AppendLine($"{book.name} - {book.edintion} - ${book.price:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            List<string> cats = input.Split(" ").Select(C => C.ToLower()).ToList();

            var booksByCategories = context
                .Books
                .Where(b => b.BookCategories.Any(c => cats.Contains(c.Category.Name.ToLower())))
                .Select(b => b.Title)
                .ToList()
                .OrderBy(b => b);


            StringBuilder sb = new StringBuilder();

            foreach (var book in booksByCategories)
            {
                sb.AppendLine($"{book}");
            }

            return sb.ToString().TrimEnd();

        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {

            var booksNotInParticularYear = context
                .Books
                .Where(b => b.ReleaseDate.Value.Year != year)
                .Select(b => new { name = b.Title, id = b.BookId })
                .ToList()
                .OrderBy(b => b.id);

            StringBuilder sb = new StringBuilder();

            foreach (var book in booksNotInParticularYear)
            {
                sb.AppendLine($"{book.name}");
            }

            return sb.ToString().TrimEnd();

        }

        public static string GetBooksByPrice(BookShopContext context)
        {

            decimal priceLimit = 40;

            var booksUnderPriceRange = context
                .Books
                .Where(b => b.Price > priceLimit)
                .Select(b => new
                {
                    Name = b.Title,
                    Price = b.Price
                })
                .OrderByDescending(b => b.Price)
                .ToList();


            StringBuilder sb = new StringBuilder();

            foreach (var book in booksUnderPriceRange)
            {
                sb.AppendLine($"{book.Name} - ${book.Price:f2}");
            }

            return sb.ToString().TrimEnd();

        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            var goldenBooks = context
                .Books
                .Where(b => b.EditionType == EditionType.Gold && b.Copies < 5000)
                .Select(b => new { name = b.Title, id = b.BookId })
                .ToList()
                .OrderBy(b => b.id);

            StringBuilder sb = new StringBuilder();

            foreach (var book in goldenBooks)
            {
                sb.AppendLine(book.name);
            }

            return sb.ToString().TrimEnd();

        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            AgeRestriction ageRestriction = Enum.Parse<AgeRestriction>(command, true);

            var books = context
                .Books
                .Where(b => b.AgeRestriction == ageRestriction)
                .Select(b => new { name = b.Title })
                .ToList()
                .OrderBy(b => b.name);

            StringBuilder sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine(book.name);
            }

            return sb.ToString().TrimEnd();
        }
    }
}
