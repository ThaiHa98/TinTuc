using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TinTuc.Domain.Model;
using TinTuc.API.Common;
using MediatR;
using TinTuc.Application.Features.CategoryCreates.CreatesCategory;
using TinTuc.Application.Features.CategoryCreates.UpdateCategory;
using TinTuc.Application.Features.CategoryCreates.DeleteCategory;
using TinTuc.Application.Features.CategoryCreates.GetPagedAsync;
using TinTuc.Domain.PagingRequest;

namespace TinTuc.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryRequest request)
        {
            if (request == null)
            {
                return BadRequest(new XBaseResult
                {
                    success = true,
                    httpStatusCode = (int)HttpStatusCode.BadRequest,
                    message = "All data fields have not been filled in"
                });
            }
            try
            {
                var response = await _mediator.Send(request);
                return Ok(new XBaseResult
                {
                    data = request,
                    success = true,
                    httpStatusCode = (int)HttpStatusCode.OK,
                    message = "Create Successfully"
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
        [HttpPost("Update")]
        public async Task<IActionResult> UpdateCategory([FromBody] UpdateCategoryRequest request)
        {
            if (request == null)
            {
                return BadRequest(new XBaseResult
                {
                    success = false,
                    httpStatusCode = (int)HttpStatusCode.BadRequest,
                    message = "All data fields have not been filled in"
                });
            }
            try
            {
                var response = _mediator.Send(request);
                return Ok(new XBaseResult
                {
                    data = request,
                    success = true,
                    httpStatusCode = (int)HttpStatusCode.OK,
                    message = "Update Category Successfully"
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
        public async Task<IActionResult> DeleteCategory([FromBody] DeleteCategoryRequest request)
        {
            if (request == null)
            {
                return BadRequest(new XBaseResult
                {
                    success = false,
                    httpStatusCode = (int)HttpStatusCode.BadRequest,
                    message = "Id has not been entered"
                });
            }
            try
            {
                var response = _mediator.Send(request);
                return Ok(new XBaseResult
                {
                    data = request,
                    success = true,
                    httpStatusCode = (int)HttpStatusCode.OK,
                    message = "Delete Category Successfully"
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
        public async Task<IActionResult> GetAllCategory([FromQuery] PagingRequestBase request)
        {
            try
            {
                var getAll = await _mediator.Send(new GetAllCategoryQuery(request));
                return Ok(new XBaseResult
                {
                    data = getAll,
                    success = true,
                    httpStatusCode = (int)HttpStatusCode.OK,
                    totalCount = getAll.Count(),
                    message = "Successfully"
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
