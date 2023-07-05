using System;
using Module_25.DAL.Entities;
using Module_25.DAL.Repositories;

namespace Module_25
{
    class Program
    {
        public static IUserRepository userRepository = new UserRepository();
        public static IBookRepository bookRepository = new BookRepository();

        static void Main(string[] args)
        {
            // Создаем контекст для добавления данных
            using (var db = new AppContext())
            {
                // Пересоздаем базу
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

                // Заполняем данными                
                var book1 = new Book { Name = "Три товарища", Year = 2010 };
                var book2 = new Book { Name = "На западном фронте без перемен", Year = 2008 };

                var bookDescription1 = new BookDescription { Author = "Эрих Мария Ремарк", Genre = "Роман", BookId = 1, Book = book1 };
                var bookDescription2 = new BookDescription { Author = "Эрих Мария Ремарк", Genre = "Роман", BookId = 2, Book = book2 };

                var user1 = new User { Name = "Anton", Email = "anton@ya.ru", Books = { book1, book2} };
                var user2 = new User { Name = "Boris", Email = "boris@ya.ru", Books = { book1, book2 } };

                userRepository.Create(db, user1);
                userRepository.Create(db, user2);

                bookRepository.Create(db, book1);
                bookRepository.Create(db, book2);
            }
            
            // Создаем контекст для изменения данных
            using (var db = new AppContext())
            {
                userRepository.UpdateName(db, 1, "Antonina");
                bookRepository.UpdateYear(db, 1, 2020);
            }
        }
    }
}
