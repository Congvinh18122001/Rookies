using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryManagement.Models
{
    public interface IUserRepository
    {
        List<User> ListAll();
        User GetById(int id);
    }
}