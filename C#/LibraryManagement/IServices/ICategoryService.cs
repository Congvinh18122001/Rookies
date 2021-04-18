using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryManagement.Models
{
    public interface ICategoryService
    {
       bool Delete(int id);
    }
}