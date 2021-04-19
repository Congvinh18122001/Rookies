using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryManagement.Models
{
    public interface ICategoryRepository
    {
        Category Add(Category category);
        Category Update(Category category);
        void Remove(Category category);
        IEnumerable<Category> ListAll();
        Category GetById(int id);

    }
}