using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Module_25.DAL.Entities;

namespace Module_25.DAL.Repositories
{
    public class BookRepository : IBookRepository
    {
        public void Create(AppContext appContext, Book book)
        {
            using (appContext)
            {
                appContext.Books.Add(book);
                appContext.SaveChanges();
            }
        }

        public void Remove(AppContext appContext, Book book)
        {
            using (appContext)
            {
                appContext.Books.Remove(book);
                appContext.SaveChanges();
            }
        }

        public Book FindById(AppContext appContext, int id)
        {
            using (appContext)
            {
                return (Book)appContext.Books.Where(b => b.Id == id);
            }
        }

        public List<Book> FindAll(AppContext appContext)
        {
            using (appContext)
            {
                return appContext.Books.ToList();
            }
        }

        public void UpdateYear(AppContext appContext, int id, int year)
        {
            using (appContext)
            {
                Book book = FindById(appContext, id);
                book.Year = year;
                appContext.SaveChanges();
            }
        }

        public List<Book> GetBooksByGenreAndYears(AppContext appContext, string genre, int minYear, int maxYear)
        {
            using (appContext)
            {
                return appContext.Books.Join(appContext.BookDescriptions, b => b.Id, bd => bd.BookId, 
                    (b, bd) => new { Book = bd.Book, BookGenre = bd.Genre, BookYear = b.Year}).
                    Where(b => b.BookGenre == genre && b.BookYear <= maxYear 
                && b.BookYear >= minYear).Select(b => b.Book).ToList();
            }
        }

        public int GetBooksCountByAuthor(AppContext appContext, string author)
        {
            using (appContext)
            {
                return appContext.BookDescriptions.Count(b => b.Author == author);
            }
        }

        public int GetBooksCountByGenre(AppContext appContext, string genre)
        {
            using (appContext)
            {
                return appContext.BookDescriptions.Count(b => b.Genre == genre);
            }
        }

        public bool HasBookByAuthorAndName(AppContext appContext, string author, string name)
        {
            using (appContext)
            {
                return appContext.BookDescriptions.Include(b => b.Book).Any(b => b.Author == author && b.Book.Name == name);
            }
        }

        public Book GetLastReleasedBook(AppContext appContext)
        {
            using (appContext)
            {
                return (Book)appContext.Books.Where(b => b.Year == appContext.Books.Select(b => b.Year).Max());
            }
        }

        public List<Book> GetBooksOrderedByName(AppContext appContext)
        {
            using (appContext)
            {
                return appContext.Books.OrderBy(b => b.Name).ToList();
            }
        }

        public List<Book> GetBooksOrderedByDescYear(AppContext appContext)
        {
            using (appContext)
            {
                return appContext.Books.OrderByDescending(b => b.Year).ToList();
            }
        }
    }

    public interface IBookRepository
    {
        void Create(AppContext appContext, Book book);
        void Remove(AppContext appContext, Book book);
        Book FindById(AppContext appContext, int id);
        List<Book> FindAll(AppContext appContext);
        void UpdateYear(AppContext appContext, int id, int year);
    }
}
