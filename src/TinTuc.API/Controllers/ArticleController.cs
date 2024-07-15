using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TinTuc.Application.Services.Service;
using TinTuc.API.Common;
using TinTuc.ModelDto.ModelDto;

namespace TinTuc.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly ArticleService _articleService;
        public ArticleController(ArticleService articleService) 
        {
            _articleService = articleService;
        }

        [HttpPost("Create")]
        public IActionResult CreateArticle([FromForm] ArticleDto articleDto, [FromForm] IFormFile image)
        {
            try
            {
                if (articleDto == null)
                {
                    return BadRequest("All data fields have not been filled in");
                }
                var article = _articleService.CreateArticle(articleDto, image);
                return Ok(new XBaseResult
                {
                    data = article,
                    success = true,
                    httpStatusCode = (int)HttpStatusCode.OK,
                    message = "Create Article Successfully"
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
