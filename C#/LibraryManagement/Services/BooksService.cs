using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Models
{
    public class BooksService : IBooksService
    {
        private readonly IBooksRepository _repo;
        private readonly ICategoryRepository _categoryRepo;
        public BooksService(IBooksRepository repo,ICategoryRepository categoryRepo)
        {
            _repo = repo;
            _categoryRepo = categoryRepo;
        }

       public Book Update(Book book){
           Book getBook = _repo.GetById(book.ID);
           if (getBook != null)
           {
               return _repo.Update(book);
           }
           return null;
       }
       public bool Delete(int? id){
           if (id.HasValue)
           {
               Book book = _repo.GetById(id.Value);
               if (book != null)
               {
                   _repo.Remove(book);
                   return true;
               }
           }
           return false;
       }
       public IEnumerable<Book> GetBooksByCategory(int id){
            if (CheckCategory(id))
            {
                IEnumerable<Book> books = _repo.ListAll().Where(b=>b.CategoryID==id).OrderByDescending(b=>b.CreatedAt);
                foreach (var item in books)
                {
                    item.Category = null;
                }
                return books;
            }
            return null;
       }
       bool CheckCategory(int id){
          Category category = _categoryRepo.GetById(id);
          if (category != null)
          {
              return true;
          }
          return false;
       }
    }
}