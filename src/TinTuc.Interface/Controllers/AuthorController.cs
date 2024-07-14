using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TinTuc.Application.Services.Service;
using TinTuc.Domain.Model;
using TinTuc.Interface.Common;

namespace TinTuc.Interface.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly AuthorService _authorService;
        public AuthorController(AuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpPost("Create")]
        public IActionResult CreateAuthor(Author author)
        {
            try
            {
                var create = _authorService.CreateAuthor(author);
                return Ok(new XBaseResult
                {
                    data = create,
                    success = true,
                    httpStatusCode = (int)HttpStatusCode.OK,
                    message = "Create Author Successfully"
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
        public IActionResult DeleteAuthor(int id)
        {
            try
            {
                if (id == null)
                {
                    throw new Exception("Author id has not been entered");
                }
                _authorService.DeleteAuthor(id);
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

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            try
            {
                var author = _authorService.GetAllAuthor();
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

        [HttpGet("GetById")]
        public IActionResult GetAuthorId(int id) 
        {
            try
            {
                if (id == null)
                {
                    throw new Exception("Id not entered");
                }
                var query = _authorService.GetAuthorId(id);
                return Ok(new XBaseResult
                {
                    data = query,
                    success = true,
                    httpStatusCode = (int)HttpStatusCode.OK,
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
        public IActionResult UpdateAuhor([FromBody]Author author)
        {
            try
            {
                if (author == null)
                {
                    throw new Exception("Author data fields have not been fully entered");
                }
                _authorService.UpdateAuthor(author);
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
                    success= false,
                    httpStatusCode = (int)HttpStatusCode.BadRequest,
                    message = ex.Message
                });
            }
        }
    }
}
