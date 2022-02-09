using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PocoPanel.Application.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PocoPanel.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class ProfileApiController : BaseApiController
    {
        private readonly IGetUser _IGetUser;
        public ProfileApiController(IGetUser iGetUser)
        {
            _IGetUser = iGetUser;
        }

        [HttpPost("GetProfile")]
        public async Task<IActionResult> GetProfile(string ApiToken)
        {
            var user = await _IGetUser.GetUserByToken(ApiToken);
            if (user == null)
                return NotFound("User Not Found!");
            return Ok(user);
        }

    }
}
