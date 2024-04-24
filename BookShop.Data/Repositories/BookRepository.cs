using BookShop.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Data.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly BookShopDbContext _context;

        public BookRepository(BookShopDbContext context)
        {
            _context = context;

            if (!_context.Books.Any())
            {
                _context.Books.Add(new Book
                {
                    BookName = "Real Madrid",
                    Price = 9000.9,
                    Author = "Carlo Ancelloti",
                    Publisher = "Florentino Perez"
                });

                _context.Books.Add(new Book
                {
                    BookName = "Barca",
                    Price = 5000.6,
                    Author = "Xavi Hernandez",
                    Publisher = "Joan Laporta"
                });

                _context.Books.Add(new Book
                {
                    BookName = "Atletico Madrid",
                    Price = 6000.7,
                    Author = "Diego Simone",
                    Publisher = "Enrique Cerezo"
                });

                _context.SaveChanges();
            }
        }

        public void AddBook(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return _context.Books.ToList();
        }

        public Book GetBookDetails(int bookId)
        {
            return _context.Books.FirstOrDefault(x => x.Id == bookId);
        }
    }

    public interface IBookRepository
    {
        void AddBook(Book book);
        Book GetBookDetails(int bookId);
        IEnumerable<Book> GetAllBooks();
    }
}
