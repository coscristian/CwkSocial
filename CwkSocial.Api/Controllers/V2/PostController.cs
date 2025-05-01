using Asp.Versioning;
using Cwk.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace CwkSocial.Api.Controllers.V2
{
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class PostController : Controller
    {        
        [HttpGet]
        [MapToApiVersion("2.0")]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            var post = new Post { Id = id, Text = "Hello, universe" };
            return Ok(post);
        }
    }
}
