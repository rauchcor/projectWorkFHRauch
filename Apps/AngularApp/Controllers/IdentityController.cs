using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace AngularClient.Controllers
{
    [Route("api/[controller]")]
    public class IdentityController: Controller
    {
        //[Authorize]
        //public async Task<IActionResult> Index()
        //{
        //    var apiCallUsingUserAccessToken = await ApiCallUsingUserAccessToken();
        //    ViewData["apiCallUsingUserAccessToken"] = apiCallUsingUserAccessToken.IsSuccessStatusCode ? await apiCallUsingUserAccessToken.Content.ReadAsStringAsync() : apiCallUsingUserAccessToken.StatusCode.ToString();

        //    return View();
        //}

        //public async Task<HttpResponseMessage> ApiCallUsingUserAccessToken()
        //{
        //    var accessToken = await HttpContext.GetTokenAsync("access_token");

        //    var client = new HttpClient();
        //    client.SetBearerToken(accessToken);
        //    return await client.GetAsync("http://localhost:5001/api/Cars/claims");
        //}

        //public async Task Logout()
        //{
        //    await HttpContext.Authentication.SignOutAsync("Cookies");
        //    await HttpContext.Authentication.SignOutAsync("oidc");
        //}
    }
}
