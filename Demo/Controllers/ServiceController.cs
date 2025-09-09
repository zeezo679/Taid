using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Demo.Controllers
{
    public class ServiceController : Controller
    {
        [Authorize]
        public IActionResult TestClaims()
        {
            var userClaims = User.Claims;
            var claim = userClaims.FirstOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier);
            return Content($"Id : {claim.Value}");
        }
    }
}
