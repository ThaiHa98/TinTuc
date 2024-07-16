using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TinTuc.Application.Services.Interface;
using TinTuc.Application.Services.Service;
using TinTuc.Domain.Model;
using TinTuc.API.Common;

namespace TinTuc.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryService _categoryService;
        public CategoryController(CategoryService categoryService) 
        {
            _categoryService = categoryService;
        }

        [HttpPost("Create")]
        public IActionResult CreateCategory([FromBody]Category category) 
        {
            try
            {
                if (category == null)
                {
                    throw new ArgumentNullException(nameof(category), "all data fields have not been filled in");
                }
                var createCategory = _categoryService.CreateCategory(category);
                return Ok(new XBaseResult
                {
                    data = createCategory,
                    success = true,
                    httpStatusCode = (int)HttpStatusCode.OK,
                    message = "Create Category Successfully"
                });
            }
            catch (Exception ex) 
            {
                return BadRequest(new XBaseResult
                {
                    success = false,
                    httpStatusCode = (int)HttpStatusCode.BadRequest,
                    message = ex.Message
                });
            }
        }

        [HttpPost("Delete")]
        public IActionResult DeleteCategory(int id) 
        {
            try
            {
                if (id == null)
                {
                    throw new Exception("Id not filled in yet ");
                }
                _categoryService.DeleteCategory(id);
                return Ok(new XBaseResult
                {
                    success = true,
                    httpStatusCode = (int)HttpStatusCode.NotFound,
                    message = "Delete Successfully"
                });
            }
            catch (Exception ex) 
            {
                return BadRequest(new XBaseResult
                {
                    success = false,
                    httpStatusCode = (int)HttpStatusCode.BadRequest,
                    message = ex.Message
                });
            }
        }

        [HttpGet("GetById")]
        public IActionResult GetCategoryId(int id)
        {
            try
            {
                if (id == null)
                {
                    throw new Exception("Id not entered");
                }
                var query = _categoryService.GetById(id);
                return Ok(new XBaseResult
                {
                    data = query,
                    success = true,
                    httpStatusCode = (int)HttpStatusCode.OK,
                    message = "Category"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new XBaseResult
                {
                    success = false,
                    httpStatusCode = (int)HttpStatusCode.BadRequest,
                    message = ex.Message
                });
            }
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            try
            {
                var author = _categoryService.GetCategory();
                return Ok(new XBaseResult
                {
                    data = author,
                    success = true,
                    httpStatusCode = (int)HttpStatusCode.OK,
                    totalCount = author.Count(),
                    message = "Author"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new XBaseResult
                {
                    success = false,
                    httpStatusCode = (int)HttpStatusCode.BadRequest,
                    message = ex.Message
                });
            }
        }

        [HttpPut("Update")]
        public IActionResult UpdateCategory([FromBody] Category category)
        {
            try
            {
                if (category == null)
                {
                    throw new Exception("Author data fields have not been fully entered");
                }
                _categoryService.UpdateCategory(category);
                return Ok(new XBaseResult
                {
                    success = true,
                    httpStatusCode = (int)HttpStatusCode.OK,
                    message = "Update Successfully"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new XBaseResult
                {
                    success = false,
                    httpStatusCode = (int)HttpStatusCode.BadRequest,
                    message = ex.Message
                });
            }
        }
    }
}
