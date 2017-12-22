using Microsoft.AspNetCore.Mvc;

namespace WebApplication5.Api.Controllers
{
    [Route("api")]
    public class ApiController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("API Alive");
        }
    }
}