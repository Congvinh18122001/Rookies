using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryManagement.Models
{
    public interface IRequestDetailRepository
    {
        void Add(RequestDetail requestDetail);
        IEnumerable<RequestDetail> ListAll();
        RequestDetail GetById(int id);
    }
}