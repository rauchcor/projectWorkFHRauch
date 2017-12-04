
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using IdentityServer4.AccessTokenValidation;

namespace IdentityServer.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = IdentityServerAuthenticationDefaults.AuthenticationScheme)]
    public class AuthController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var claims = User.Claims.Select(c => new { c.Type, c.Value });
            return new JsonResult(claims);
        }
    }
}
