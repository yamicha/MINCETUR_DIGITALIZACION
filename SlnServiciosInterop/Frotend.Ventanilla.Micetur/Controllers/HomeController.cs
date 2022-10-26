using System.Diagnostics;
using Frotend.Ventanilla.Micetur.Models;
using Microsoft.AspNetCore.Mvc;
using Frotend.Ventanilla.Micetur.Authorization;
using Utilitarios.Helpers.Authorization;
using Utilitarios.Recursos;
using EnServiciosDigitalizacion;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace Frotend.Ventanilla.Micetur.Controllers
{
    [Authorize]
    public class HomeController : BaseController
    {
        public  IActionResult Index()
        {
            return View();
        }

        public IActionResult AccesoDenegado()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
