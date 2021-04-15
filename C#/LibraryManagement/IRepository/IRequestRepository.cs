using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryManagement.Models
{
    public interface IRequestRepository
    {
        BorrowingRequest Add(BorrowingRequest request);
        IEnumerable<BorrowingRequest> ListAll();
        BorrowingRequest GetById(int id);
        void Update(BorrowingRequest request);
    }
}