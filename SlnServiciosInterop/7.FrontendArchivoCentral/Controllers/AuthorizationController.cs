using System;
using System.Diagnostics;
using System.Security.Claims;
using EnServiciosDigitalizacion;
using Frotend.ArchivoCentral.Micetur.Filters;
using Frotend.ArchivoCentral.Micetur.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using ServiceReference1;
using Utilitarios.Helpers.Authorization;
using Utilitarios.Recursos;

namespace Frotend.ArchivoCentral.Micetur.Controllers
{
    public class AuthorizationController : Controller
    {

        //public ActionResult antesLogin()        
        //{

        //    enUsu ent = new enUsu();

        //    ViewBag.Message = "Modifique esta plantilla para poner en marcha su aplicación ASP.NET MVC.";
        //    try
        //    {
        //        ent = ValidarUsuario(null);

        //    }
        //    catch (Exception ex)
        //    {

        //        LogSICA log = new LogSICA();
        //        UCGeneral general = new UCGeneral();
        //        log.Aplicacion = "SIDIG";
        //        log.MensajeError = ex.Message;
        //        log.Usuario = Environment.UserName;
        //        log.PC = Environment.MachineName;
        //        log.Ruta = @"C:\Temp\logSIDIG.txt";
        //        log.FechaHora = DateTime.Now;
        //        log.DetalleMensaje = ex.StackTrace;
        //        general.GrabarLog(log);
        //    }

        //    if (ent.CodUsu != 0)
        //    {
        //        Response.Write(ent.CodUsu);
        //        Session["usuario"] = ent;

        //        return RedirectToAction("Index", "Home");
        //    }
        //    else
        //    {
        //        return RedirectToAction("About");
        //    }

        //}

        //private enUsu ValidarUsuario(string CodigoUsuario)
        //{
        //    enUsu objEnUsu = new enUsu();
        //    try
        //    {

        //        int intIdSis = int.Parse(ConfigurationManager.AppSettings["id_sistema"].ToString());

        //        //objEnUsu = neUsu.traerdatosUsuario(3248);
        //        string StrCodDesEncriptado = null;
        //        string StrCodEncriptado = Request.QueryString["Cod"].ToString();

        //        string llave = neSeguridad.TraeLlave();
        //        if (!string.IsNullOrEmpty(llave)) StrCodDesEncriptado = EncripDesCrip.DesEncriptarAES(StrCodEncriptado, llave, null);

        //        int intIdUsu = int.Parse(StrCodDesEncriptado);
        //        string strLogin = neSeguridad.TraeLogin(intIdUsu);
        //        Response.Write(intIdUsu);
        //        Response.Write(strLogin);
        //        //@ViewBag.nom_usuario = strLogin;
        //        Response.Write(StrCodDesEncriptado);
        //        Response.Write(StrCodEncriptado);
        //        if (neSeguridad.TraeValidaUsuarioSistema(intIdUsu, intIdSis))
        //        {
        //            objEnUsu = neUsu.traerdatosUsuario(intIdUsu);
        //            string strRoles = neSeguridad.TraeRolesUsuario(intIdUsu, intIdSis);
        //            //usuario_rol = strRoles;
        //            FormsAuthenticationTicket Ticket = new FormsAuthenticationTicket(1, StrCodDesEncriptado, DateTime.Now, DateTime.Now.Add(FormsAuthentication.Timeout), true, strLogin, FormsAuthentication.FormsCookiePath);
        //            string strTicket = FormsAuthentication.Encrypt(Ticket);
        //            HttpCookie cookAuth = new HttpCookie(FormsAuthentication.FormsCookieName, strTicket)
        //            {
        //                Expires = DateTime.Now.Add(FormsAuthentication.Timeout)
        //            };
        //            Response.Cookies.Add(cookAuth);
        //        }
        //        else
        //        {
        //            string error = "";
        //        }

        //    }
        //    catch (Exception ex)
        //    {

        //        //  logger.Error(string.Format("Mensaje: {0} Trace: {1}", ex.Message, ex.StackTrace));

        //        LogSICA log = new LogSICA();
        //        UCGeneral general = new UCGeneral();
        //        log.Aplicacion = "SIDIG";
        //        log.MensajeError = ex.Message;
        //        log.Usuario = Environment.UserName;
        //        log.PC = Environment.MachineName;
        //        log.Ruta = @"C:\Temp\logSIDIG.txt";
        //        log.FechaHora = DateTime.Now;
        //        log.DetalleMensaje = ex.StackTrace;
        //        general.GrabarLog(log);
        //        // return MensajeError();
        //    }
        //    return objEnUsu;
        //}

        public IActionResult SignIn(string cod)
        {
            enAuditoria auditoria = new enAuditoria();
            auditoria.Limpiar();
            //using (WCFSeguridadEncripDesencripClient client = new WCFSeguridadEncripDesencripClient())
            //{
            //    string StrCodDesEncriptado = string.Empty; 
            //    string llave =  client.traeLlave();
            //    if (!string.IsNullOrEmpty(llave)) StrCodDesEncriptado = client.desencriptarAES(cod, llave);
            //    int intIdUsu = int.Parse(StrCodDesEncriptado);
            //}
                UserLogin userlogin = new UserLogin
            {
                Codusuario = "IPEREZ",
                IdUsuario = 25,
                NameApellidos = "IVAN PEREZ TINTAYA",
                IdOficina = 20,
                DesOficina = "MI CASA",
                IdPerfil = 2,
            };
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
