using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Models
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly libDbContext _dbContext;

        public CategoryRepository(libDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Category Add(Category category) {
             _dbContext.Categories.Add(category);
             _dbContext.SaveChanges();
             return category;
        }
        public Category Update(Category category) {
            Category getCategory = GetById(category.ID);
            getCategory.Name = category.Name;
            _dbContext.SaveChanges();
            return getCategory;
        }

        public void Remove(Category category) {
             _dbContext.Categories.Remove(category);
             _dbContext.SaveChanges();
        }

        public IEnumerable<Category> ListAll() => _dbContext.Categories.ToList();

        public Category GetById(int id) => _dbContext.Categories.SingleOrDefault(c => c.ID==id);
    }
}