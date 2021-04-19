using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Models
{
    public class BorrowingService : IBorrowingService
    {
        private readonly IRequestDetailRepository _requestDetail;
        private readonly IRequestRepository _request;
        private readonly IUserRepository _user;
        public BorrowingService(IRequestDetailRepository requestDetail, IRequestRepository request, IUserRepository user)
        {
            _requestDetail = requestDetail;
            _request = request;
            _user = user;
        }
        public bool UpdateRequestStatus(Borrowing request)
        {
            if (request.ID != 0 && request.Status >= (StatusRequest)0 && request.Status <= (StatusRequest)2)
            {
                BorrowingRequest borrowingRequest = _request.GetById(request.ID);
                if (borrowingRequest != null)
                {
                    borrowingRequest.Status = (int)request.Status;
                    _request.Update(borrowingRequest);
                    return true;
                }
            }
            return false;
        }
        public bool PostRequest(Borrowing borrowing)
        {
            bool isRequestValid = CheckBorrowRequestValid(borrowing.UserID);
            if (isRequestValid && borrowing.ListBookID.Count <= 5 && borrowing.ListBookID.Count > 0 && borrowing.UserID > 0)
            {
                BorrowingRequest borrowingRequest = AddBorrowingRequest(borrowing.UserID);
                foreach (var bookID in borrowing.ListBookID)
                {
                    AddRequestDetail(bookID, borrowingRequest.ID);
                }
                return true;
            }
            return false;
        }
        public BorrowingRequest GetByID(int id)
        {
            BorrowingRequest borrowingRequest = _request.GetById(id);
            if (borrowingRequest != null)
            {
                List<RequestDetail> RequestDetails = ListDetail(borrowingRequest.ID);
                User user = getUser(borrowingRequest.UserID);
                if (RequestDetails.Count > 0 && user != null)
                {
                    borrowingRequest.User = user;
                    borrowingRequest.RequestDetails = RequestDetails;
                    return borrowingRequest;
                }
            }
            return null;
        }
        User getUser(int id)
        {
            User user = _user.GetById(id);
            user.Password = null;
            return user;
        }
        List<RequestDetail> ListDetail(int RequestID)
        {
            List<RequestDetail> list = _requestDetail.ListAll()
            .Where(p => p.RequestID == RequestID)
            .ToList();
            return list;
        }
        bool CheckBorrowRequestValid(int UserID)
        {
            List<BorrowingRequest> requests = _request.ListAll()
            .Where(p => p.UserID == UserID && p.RequestAt.Year == DateTime.Now.Year && p.RequestAt.Month == DateTime.Now.Month)
            .ToList();

            return (requests.Count() < 3);
        }
        void AddRequestDetail(int BookID, int RequestID)
        {
            RequestDetail detail = new RequestDetail();
            detail.RequestID = RequestID;
            detail.BookID = BookID;
            _requestDetail.Add(detail);
        }
        BorrowingRequest AddBorrowingRequest(int UserID)
        {
            BorrowingRequest borrowRequest = new BorrowingRequest();
            borrowRequest.UserID = UserID;
            borrowRequest.Status = 0;
            borrowRequest.RequestAt = DateTime.Now;
            return _request.Add(borrowRequest);
        }
    }
}