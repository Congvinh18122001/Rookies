using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Models
{
    public class UserRepository : IUserRepository
    {
        private readonly libDbContext _dbContext;

        public UserRepository(libDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<User> ListAll() => _dbContext.Users.ToList();
        public User GetById(int id) => _dbContext.Users.SingleOrDefault(u=>u.ID==id);
    }
}