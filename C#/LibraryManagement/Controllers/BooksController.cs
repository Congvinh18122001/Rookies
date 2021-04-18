using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using LibraryManagement.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace LibraryManagement.Controllers
{
    [Route("api/Books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly ILoginService _loginService;
        private readonly IBooksService _service;
        private readonly IBooksRepository _repo;
        public BooksController(IBooksService service, IBooksRepository repo, ILoginService loginService)
        {
            _repo = repo;
            _service = service;
            _loginService = loginService;
        }
        [HttpGet]
        public ActionResult<List<Book>> Get()
        {
            return Ok(_repo.ListAll().OrderByDescending(x => x.CreatedAt));
        }
        [HttpGet("/GetByCategory/{id}")]
        public ActionResult<List<Book>> GetByCategory(int id)
        {
            List<Book> books = _service.GetBooksByCategory(id).ToList();
            if (books != null && books.Count > 0)
            {
                return Ok(books);
            }
            return NoContent();
        }
        [HttpGet("{id}")]
        public ActionResult<Book> Get(int id)

        {
            Book book = _repo.GetById(id);
            if (book != null)
            {
                return Ok(book);
            }
            return NotFound();
        }
        
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult<Book> Post(BookVM bookCreateRequest)
        {

            if (bookCreateRequest != null)
            {
                Book book = new Book();
                book.Name = bookCreateRequest.Name;
                book.Author = bookCreateRequest.Author;
                book.CategoryID = bookCreateRequest.CategoryID;
                book.CreatedAt = DateTime.Now;
                book = _repo.Add(book);
                return CreatedAtAction(nameof(Get), new { id = book.ID }, book);
            }
            return BadRequest();
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public ActionResult<Book> Put(BookVM bookEditRequest)
        {
            Book  book = new Book
            {
                ID = bookEditRequest.ID,
                Name=bookEditRequest.Name,
                Author=bookEditRequest.Author,
                CategoryID=bookEditRequest.CategoryID
            };
            book = _service.Update(book);
            if (book == null)
            {
                return NotFound();
            }
            book.Category.Books = null;
            return Ok(book);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {

            if (_service.Delete(id))
            {
                return Ok();
            }
            return NotFound();
        }
    }
}