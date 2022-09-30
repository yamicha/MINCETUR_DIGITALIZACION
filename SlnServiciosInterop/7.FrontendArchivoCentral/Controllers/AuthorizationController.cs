using System.Diagnostics;
using Frotend.ArchivoCentral.Micetur.Models;
using Microsoft.AspNetCore.Mvc;
using Frotend.ArchivoCentral.Micetur.Authorization;
using Utilitarios.Helpers.Authorization;
using Utilitarios.Recursos;
using EnServiciosDigitalizacion;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System;
using System.Security.Claims;

namespace Frotend.ArchivoCentral.Micetur.Controllers
{
    public class AuthorizationController : Controller
    {
        public IActionResult Index()
        {
            enAuditoria auditoria = new enAuditoria();
            UserLogin userlogin = new UserLogin
            {
                Codusuario = "IPEREZ",
                IdUsuario = 3240,
                NameApellidos = "IVAN PEREZ TINTAYA",
                IdOficina = 20,
                DesOficina = "MI CASA"

            };
            auditoria.Limpiar();
            try
            {
                if (userlogin != null)
                {
                    //HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                    var identity = new Authentication().CreateIdentity(userlogin);
                    ClaimsPrincipal userPrincipal = new ClaimsPrincipal(identity);
                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, userPrincipal, new AuthenticationProperties
                    {
                        ExpiresUtc = DateTime.Now.AddDays(1)
                    });
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return RedirectToAction("AccesoDenegado", "Authorization");
                }
            }
            catch (Exception ex)
            {
                Log.Guardar(ex.Message.ToString());
                return RedirectToAction("AccesoDenegado", "Authorization");
            }

        }

        [Route("acceso-denegado")]
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
