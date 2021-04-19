using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryManagement.Models
{
    public interface ILoginService
    {
         User Login(string username, string password);
    }
}