using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;

namespace Basic.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() 
        {
            return View();
        }
        [Authorize]
        public IActionResult Secret()
        {
            return View();
        }
        public IActionResult Authenticate() 
        {
            var basicClaims = new List<Claim>() 
            {
                new Claim(ClaimTypes.Name , "Yash"),
                new Claim(ClaimTypes.Email,"yash@gmail.com"),
                new Claim("Basic.Say","Very good men")
            };

            var licenseClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.Email,"yash@gmail.com"),
                new Claim("License.Grade","A+")
            };
            var basicIdentity = new ClaimsIdentity(basicClaims,"Basic identity");
            var licenseIdentity = new ClaimsIdentity(basicClaims, "Goverment identity");

            var userPrincipal = new ClaimsPrincipal(new[] { basicIdentity, licenseIdentity });

            HttpContext.SignInAsync(userPrincipal);

            return RedirectToAction("Index");
        }

    }
}
