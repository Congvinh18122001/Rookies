using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LibraryManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
namespace LibraryManagement.Controllers
{
    [Route("api/Category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ILoginService _loginService;
        private readonly ICategoryService _categoryService;
        private readonly ICategoryRepository _repo;
        public CategoryController(ICategoryService categoryService, ICategoryRepository repo, ILoginService loginService)
        {
            _repo = repo;
            _categoryService = categoryService;
            _loginService = loginService;
        }
        [HttpGet]
        public ActionResult<List<Category>> Get()
        {
            return Ok(_repo.ListAll());
        }

        [HttpGet("{id}")]
        public ActionResult<Category> Get(int id)
        {
            Category category = _repo.GetById(id);
            if (category != null)
            {
                return Ok(category);
            }
            return NotFound();
        }
        // [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult<Category> Post(Category category)
        {

            if (category != null)
            {
                category.CreatedAt = DateTime.Now;
                category = _repo.Add(category);
                return CreatedAtAction(nameof(Get), new { id = category.ID }, category);
            }
            return BadRequest();
        }

        [HttpPut]
        public ActionResult<Category> Put(Category category)
        {

            category = _categoryService.Update(category);
            if (category != null)
            {
                return Ok(category);
            }
            return BadRequest();
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (_categoryService.Delete(id))
            {
                return Ok();
            }
            return NotFound();
        }
    }
}