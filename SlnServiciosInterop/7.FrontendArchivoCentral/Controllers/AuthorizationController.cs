using System.Diagnostics;
using Frotend.ArchivoCentral.Micetur.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Owin.Security;
using Utilitarios.Helpers.Authorization;

namespace Frotend.ArchivoCentral.Micetur.Controllers
{
    public class AuthorizationController : Controller
    {
        private readonly IAuthenticationManager _authenticationManager;
        public AuthorizationController(IAuthenticationManager authenticationManager) {
            _authenticationManager = authenticationManager;
        }
        // GET: AuthorizationController
        public ActionResult Index()
        {
            var authService = new AuthenticationService(_authenticationManager);
            var authenticationResult = authService.SignIn("", "", true);
            return View();
        }

    }
}
