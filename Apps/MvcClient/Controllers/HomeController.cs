using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using IdentityModel.Client;

namespace MvcClient.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult Secure()
        {
            ViewData["Message"] = "Secure page.";

            return View();
        }

        public IActionResult Login()
        {
            return Challenge(new AuthenticationProperties()
            {
                RedirectUri = "Home/Secure"
            }, "oidc");
        }

      
        public async Task Logout()
        {
            /*because the Spezification is designed to run on multiple domains
            for the user to be logged out everywhere he has to be send back to the token server
            it triggers the end_session_endpoint which we have seen before in the wellknown openidconnect-configuration
            this implements the sign out spezification
            */
            await HttpContext.SignOutAsync("Cookies");
            await HttpContext.SignOutAsync("oidc");
        }

        public IActionResult Error()
        {
            return View();
        }


        public async Task<IActionResult> CallApiUsingUserAccessToken()
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");

            var client = new HttpClient();
            client.SetBearerToken(accessToken);
 

            var response = await client.GetAsync("http://localhost:5001/api/Cars/claims");
            if (!response.IsSuccessStatusCode)
            {
                ViewBag.Json = "Error" + response.StatusCode;
            
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                ViewBag.Json = JArray.Parse(content).ToString();
            
            }
            return View("json");

        }
    }
}