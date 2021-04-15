using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryManagement.Models
{
    public interface IBooksRepository
    {
        Book Add(Book book);
        Book Update(Book book);
        void Remove(Book book);
        IEnumerable<Book> ListAll();
        Book GetById(int id);
    }
}