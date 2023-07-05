using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public void UpdateYear(AppContext appContext, int id, string year)
        {
            using (appContext)
            {
                Book book = FindById(appContext, id);
                book.Year = year;
                appContext.SaveChanges();
            }
        }
    }

    public interface IBookRepository
    {
        void Create(AppContext appContext, Book book);
        void Remove(AppContext appContext, Book book);
        Book FindById(AppContext appContext, int id);
        List<Book> FindAll(AppContext appContext);
        void UpdateYear(AppContext appContext, int id, string year);
    }
}
