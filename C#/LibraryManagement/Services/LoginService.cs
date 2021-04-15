using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Models
{
    public class LoginService : ILoginService
    {
        private readonly IUserRepository _repo;

        public LoginService(IUserRepository repo)
        {
            _repo = repo;
        }

        public User Login(string username, string password)
        {
            if (String.IsNullOrEmpty(username) || String.IsNullOrEmpty(password))
            {
                return null;
            }
            return _repo.ListAll()
            .SingleOrDefault(u => u.Username == username && u.Password == password);
        }
    }
}