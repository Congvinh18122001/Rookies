using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryManagement.Models
{
    public interface IBooksService
    {
        Book Update(Book book);
        bool Delete(int id);
        IEnumerable<Book> GetBooksByCategory(int id);
    }
}