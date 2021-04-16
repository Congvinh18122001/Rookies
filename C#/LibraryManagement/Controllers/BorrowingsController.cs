using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LibraryManagement.Models;
namespace LibraryManagement.Controllers
{
    [Route("api/Borrowings")]
    [ApiController]
    public class BorrowingsController : ControllerBase
    {
        private readonly ILoginService _loginService;
        private readonly IRequestRepository _repo;
        private readonly IBorrowingService _service;
        public BorrowingsController(IBorrowingService service, IRequestRepository repo, ILoginService loginService)
        {
            _service = service;
            _repo = repo;
            _loginService = loginService;
        }
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
        [HttpGet("User/{userId}")]
        public ActionResult<List<BorrowingRequest>> GetByUser(int userId)
        {
            List<BorrowingRequest> list = _repo.ListAll().Where(r => r.UserID==userId).ToList();
            if (list.Count() > 0)
            {
                return Ok(list);
            }
            return NoContent();
        }

        [HttpGet("{id}")]
        public ActionResult<BorrowingRequest> Get(int? id)
        {

            BorrowingRequest borrowingRequest = _service.GetByID(id.Value);
            if (borrowingRequest != null)
            {
                return Ok(borrowingRequest);
            }
            return NotFound();
        }

        [HttpPost("api/Borrowings/RequestBook")]
        public ActionResult Post([FromBody] Borrowing borrowing)
        {

            if (borrowing == null)
            {
                return BadRequest("Borrow request is empty !");
            }
            bool status = _service.PostRequest(borrowing);
            if (status)
            {
                return Ok();
            }
            return BadRequest("Over licensing limits in this month !!");
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, BorrowingRequest request)
        {

            if (id != request.ID)
            {
                return BadRequest("");
            }
            bool check = _service.UpdateStatus(request);
            if (check)
            {
                return Ok();
            }
            return BadRequest("");
        }
    }
}