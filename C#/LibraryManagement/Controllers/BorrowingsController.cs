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
            string username = Request.Headers["username"].ToString();
            string password = Request.Headers["password"].ToString();
            User user = _loginService.Login(username, password);
            if (user == null || user.RoleID != 1)
            {
                return Unauthorized();
            }
            List<BorrowingRequest> list = _repo.ListAll().ToList();
            if (list.Count() > 0)
            {
                return Ok(list);
            }
            return NoContent();
        }
        [HttpGet("GetByUser")]
        public ActionResult<List<BorrowingRequest>> GetByUser()
        {
            string username = Request.Headers["username"].ToString();
            string password = Request.Headers["password"].ToString();
            User user = _loginService.Login(username, password);
            if (user == null)
            {
                return Unauthorized();
            }
            List<BorrowingRequest> list = _repo.ListAll().Where(r => r.UserID==user.ID).ToList();
            if (list.Count() > 0)
            {
                return Ok(list);
            }
            return NoContent();
        }

        [HttpGet("{id}")]
        public ActionResult<BorrowingRequest> Get(int? id)
        {
            string username = Request.Headers["username"].ToString();
            string password = Request.Headers["password"].ToString();
            User user = _loginService.Login(username, password);
            if (user == null || user.RoleID != 1)
            {
                return Unauthorized();
            }
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
            string username = Request.Headers["username"].ToString();
            string password = Request.Headers["password"].ToString();
            User user = _loginService.Login(username, password);
            if (user == null)
            {
                return Unauthorized("You must login to request book !");
            }

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
            string username = Request.Headers["username"].ToString();
            string password = Request.Headers["password"].ToString();
            User user = _loginService.Login(username, password);
            if (user == null || user.RoleID != 1)
            {
                return Unauthorized();
            }
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