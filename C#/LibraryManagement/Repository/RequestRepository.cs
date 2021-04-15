using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Models
{
    public class RequestRepository : IRequestRepository
    {
        private readonly libDbContext _dbContext;

        public RequestRepository(libDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public BorrowingRequest Add(BorrowingRequest request)
        {
            _dbContext.BorrowingRequests.Add(request);
            _dbContext.SaveChanges();
            return request;
        }

        public IEnumerable<BorrowingRequest> ListAll() => _dbContext.BorrowingRequests.ToList();

        public BorrowingRequest GetById(int id) => _dbContext.BorrowingRequests.SingleOrDefault(p=>p.ID==id);
         
        public void Update(BorrowingRequest request){
            BorrowingRequest borrowingRequest =_dbContext.BorrowingRequests.SingleOrDefault(p=>p.ID==request.ID);
            borrowingRequest = request;
            _dbContext.SaveChanges();
        }
    }
}