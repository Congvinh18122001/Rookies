using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Models
{
    public class BooksRepository : IBooksRepository
    {
        private readonly libDbContext _dbContext;

        public BooksRepository(libDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Book Add(Book book)
        {
            _dbContext.Books.Add(book);
            _dbContext.SaveChanges();
            return book;
        }
        public Book Update(Book book)
        {
            Book getBook = GetById(book.ID);
            if (!String.IsNullOrEmpty(book.Name))
            {
                getBook.Name = book.Name;
            }
            if (!String.IsNullOrEmpty(book.Author))
            {
                getBook.Author = book.Author;
            }

            if (book.CategoryID != 0 )
            {
                Category category = _dbContext.Categories.SingleOrDefault(c => c.ID == book.CategoryID);
                if (category != null)
                {
                    getBook.CategoryID = book.CategoryID;
                }
            }

            _dbContext.SaveChanges();

            return getBook;
        }

        public void Remove(Book book)
        {
            _dbContext.Books.Remove(book);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Book> ListAll() => _dbContext.Books.ToList();

        public Book GetById(int id) => _dbContext.Books.SingleOrDefault(b => b.ID == id);
    }
}