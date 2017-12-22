using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApplication5.Api.Requests;
using WebApplication5.Api.Services;

namespace WebApplication5.Api.Controllers
{
    [Route("api/auth")]
    public class AuthController : Controller
    {
        private readonly AccountService accountService;

        public AuthController(AccountService accountService)
        {
            this.accountService = accountService;
        }

        [HttpPost("accounts")]
        public async Task<IActionResult> Register(CreateAccount request)
        {
            return CreatedAtRoute("GetAccount", new
            {
                AccountId = 123
            }, new { });
        }

        [HttpGet("accounts/{accountId}", Name = "GetAccount")]
        public async Task<IActionResult> GetAccount(int accountId)
        {
            return Ok();
        }
    }
}
