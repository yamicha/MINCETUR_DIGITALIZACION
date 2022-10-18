using System;
using System.Diagnostics;
using System.Security.Claims;
using EnServiciosDigitalizacion;
using Frotend.ArchivoCentral.Micetur.Filters;
using Frotend.ArchivoCentral.Micetur.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Utilitarios.Helpers.Authorization;
using Utilitarios.Recursos;

namespace Frotend.ArchivoCentral.Micetur.Controllers
{
    public class AuthorizationController : Controller
    {

        public IActionResult SignIn()
        {
            enAuditoria auditoria = new enAuditoria();
            UserLogin userlogin = new UserLogin
            {
                Codusuario = "IPEREZ",
                IdUsuario = 25,
                NameApellidos = "IVAN PEREZ TINTAYA",
                IdOficina = 20,
                DesOficina = "MI CASA",
                IdPerfil = 2,
            };
            auditoria.Limpiar();
            try
            {
                if (userlogin != null)
                {
                    HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
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
        public IActionResult AccesoDenegado()
        {
            return View();
        }
        [MyAuthorize]
        public IActionResult SignOut()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("https://www.youtube.com/"); 
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
