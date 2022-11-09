using System;
using System.Diagnostics;
using System.Security.Claims;
using System.Text;
using EnServiciosDigitalizacion;
using Frotend.Ventanilla.Micetur.Filters;
using Frotend.Ventanilla.Micetur.Helpers;
using Frotend.Ventanilla.Micetur.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using ServiceReference1;
using Utilitarios.Helpers.Authorization;
using Utilitarios.Recursos;

namespace Frotend.Ventanilla.Micetur.Controllers
{
    public class AuthorizationController : Controller
    {
   
        public IActionResult SignIn(string cod)
        {
            enAuditoria auditoria = new enAuditoria();
            auditoria.Limpiar();

            UserLogin userlogin = new UserLogin
            {
                Codusuario = "IPEREZ",
                IdUsuario = 3248,
                NameApellidos = "IVAN PEREZ TINTAYA",
                IdOficina = 20,
                DesOficina = "MI CASA",
                IdPerfil = 2,
                Modulos = string.Empty, 
            };
            userlogin.token = CssToken.Generar(userlogin.IdUsuario.ToString());
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
