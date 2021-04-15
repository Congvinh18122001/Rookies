using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryManagement.Models
{
    public interface ICategoryService
    {
       Category Update(Category category);
       bool Delete(int? id);
    }
}