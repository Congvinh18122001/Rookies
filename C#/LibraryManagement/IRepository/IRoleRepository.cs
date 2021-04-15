using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryManagement.Models
{
    public interface IRoleRepository
    {
        IEnumerable<Role> ListAll();
        Role GetById(int id);
    }
}