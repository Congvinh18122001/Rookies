using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Models
{
    public class RoleRepository : IRoleRepository
    {
        private readonly libDbContext _dbContext;

        public RoleRepository(libDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Role> ListAll() => _dbContext.Roles.ToList();

        public Role GetById(int id) => _dbContext.Roles.SingleOrDefault(r=>r.ID==id);
    }
}