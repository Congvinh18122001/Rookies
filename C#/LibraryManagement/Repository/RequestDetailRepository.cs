using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Models
{
    public class RequestDetailRepository : IRequestDetailRepository
    {
        private readonly libDbContext _dbContext;

        public RequestDetailRepository(libDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(RequestDetail requestDetail)
        {
            _dbContext.RequestDetails.Add(requestDetail);
            _dbContext.SaveChanges();
        }


        public IEnumerable<RequestDetail> ListAll() => _dbContext.RequestDetails.ToList();

        public RequestDetail GetById(int id) => _dbContext.RequestDetails.SingleOrDefault(p=>p.ID == id);
    }
}