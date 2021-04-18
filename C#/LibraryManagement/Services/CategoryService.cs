using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Models
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repo;

        public CategoryService(ICategoryRepository repo)
        {
            _repo = repo;
        }
       public bool Delete(int id){

               Category category = _repo.GetById(id);
               if (category != null)
               {
                   _repo.Remove(category);
                   return true;
               }
           return false;
       }
    }
}