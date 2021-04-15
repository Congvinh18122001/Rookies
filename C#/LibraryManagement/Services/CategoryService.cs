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

       public Category Update(Category category){
           Category getCategory = _repo.GetById(category.ID);
           if (getCategory != null)
           {
               return _repo.Update(category);
           }
           return null;
       }
       public bool Delete(int? id){
           if (id.HasValue)
           {
               Category category = _repo.GetById(id.Value);
               if (category != null)
               {
                   _repo.Remove(category);
                   return true;
               }
           }
           return false;
       }
    }
}