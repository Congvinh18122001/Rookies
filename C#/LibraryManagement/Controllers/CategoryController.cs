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
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult<Category> Post(CategoryVM categoryCreateRequest)
        {

            if (categoryCreateRequest != null)
            {
                Category checkExist = _repo.ListAll().FirstOrDefault(p => p.Name == categoryCreateRequest.Name);
                if (checkExist != null)
                {
                    return NoContent();
                }
                Category category = new Category
                {
                    CreatedAt = DateTime.Now,
                    Name = categoryCreateRequest.Name

                };
                category = _repo.Add(category);
                return CreatedAtAction(nameof(Get), new { id = category.ID }, category);
            }
            return BadRequest();
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public ActionResult<Category> Put(CategoryVM categoryEditRequest)
        {
            Category category = new Category
            {
                ID = categoryEditRequest.ID,
                Name = categoryEditRequest.Name
            };
            try
            {
                category = _repo.Update(category);
                if (category != null)
                {
                    return Ok(category);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        
        [Authorize(Roles = "Admin")]
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