using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryManagement.Models
{
    public interface IBorrowingService
    {
        bool PostRequest(Borrowing borrowing);
        BorrowingRequest  GetByID(int id);
        bool UpdateRequestStatus(BorrowingRequest request);
    }
}