using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using IdentityServer4.Services;
using IdentityServer4.Stores;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjectApiNetCore.Models;

namespace IdentityServer.Controllers
{
    [SecurityHeader]
    [Microsoft.AspNetCore.Mvc.Route("consent")]
    public class ConsentController : Controller
    {
        private readonly ConsentService _consent;

        public ConsentController(
            IIdentityServerInteractionService interaction,
            IClientStore clientStore,
            IResourceStore resourceStore,
            ILogger<ConsentController> logger)
        {
            _consent = new ConsentService(interaction, clientStore, resourceStore, logger);
        }

        /// <summary>
        /// Shows the consent screen
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        [Microsoft.AspNetCore.Mvc.HttpGet]
        public async Task<IActionResult> Index([FromUri]string returnUrl)
        {
            var vm = await _consent.BuildViewModelAsync(returnUrl);
            if (vm != null)
            {
                return Ok( vm);
            }

            return BadRequest();
        }

        /// <summary>
        /// Handles the consent screen postback
        /// </summary>
        [Microsoft.AspNetCore.Mvc.HttpPost]
       // [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index([Microsoft.AspNetCore.Mvc.FromBody]ConsentInputModel model)
        {
            var result = await _consent.ProcessConsent(model);

            if (result.IsRedirect)
            {
                return Redirect(result.RedirectUri);
            }

            if (result.HasValidationError)
            {
                ModelState.AddModelError("", result.ValidationError);
            }

            if (result.ShowView)
            {
                return Ok( result.ViewModel);
            }

            return BadRequest();
        }
    }
}
