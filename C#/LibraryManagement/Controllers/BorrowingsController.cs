using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LibraryManagement.Models;
using Microsoft.AspNetCore.Authorization;

namespace LibraryManagement.Controllers
{
    [Route("api/Borrowings")]
    [ApiController]
    public class BorrowingsController : ControllerBase
    {
        private readonly IRequestRepository _repo;
        private readonly IBorrowingService _service;
        public BorrowingsController(IBorrowingService service, IRequestRepository repo)
        {
            _service = service;
            _repo = repo;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult<List<BorrowingRequest>> Get()
        {
            List<BorrowingRequest> list = _repo.ListAll().ToList();
            if (list.Count() > 0)
            {
                return Ok(list);
            }
            return NoContent();
        }

        [Authorize(Roles = "User")]
        [HttpGet("User/{userId}")]
        public ActionResult<List<BorrowingRequest>> GetByUser(int userId)
        {
            List<BorrowingRequest> list = _repo.ListAll().Where(r => r.UserID == userId).ToList();

            return Ok(list);

        }

        [Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public ActionResult<BorrowingRequest> Get(int id)
        {

            BorrowingRequest borrowingRequest = _service.GetByID(id);
            if (borrowingRequest != null)
            {
                return Ok(borrowingRequest);
            }
            return NotFound();
        }

        [Authorize(Roles = "User")]
        [HttpPost("api/Borrowings/RequestBook")]
        public ActionResult Post([FromBody] Borrowing borrowing)
        {
            if (borrowing == null)
            {
                return BadRequest("Borrow request is empty !");
            }
            try
            {

                bool isRequestSuccess = _service.PostRequest(borrowing);
                if (isRequestSuccess)
                {
                    return Ok();
                }
                return BadRequest("Over licensing limits in this month !!");
            }
            catch (Exception)
            {
                return BadRequest("Request Fails !");
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public ActionResult Put(Borrowing requestUpdate)
        {

            try
            {
                bool isUpdateSuccess = _service.UpdateRequestStatus(requestUpdate);
                if (isUpdateSuccess)
                {
                    return Ok();
                }
                return BadRequest();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
    }
}