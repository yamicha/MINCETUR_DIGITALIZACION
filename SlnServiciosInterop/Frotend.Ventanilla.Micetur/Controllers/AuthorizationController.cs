﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using EnServiciosDigitalizacion;
using Frotend.Ventanilla.Micetur.Filters;
using Frotend.Ventanilla.Micetur.Helpers;
using Frotend.Ventanilla.Micetur.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SeguridadWsdl;
using ServiceReference1;
using Utilitarios.Helpers;
using Utilitarios.Helpers.Authorization;
using Utilitarios.Recursos;

namespace Frotend.Ventanilla.Micetur.Controllers
{
    public class AuthorizationController : Controller
    {
   
        public async Task<IActionResult> SignIn(string cod)
        {
            //cod = "KTF4vWGB8cXZzPAQUdGWLA==";
            enAuditoria auditoria = new enAuditoria();
            UserLogin userlogin = null;
            auditoria.Limpiar();
            try
            {
                using (WCFSeguridadEncripDesencripClient client = new WCFSeguridadEncripDesencripClient())
                {
                    string StrCodDesEncriptado = string.Empty;
                    string llave = client.traeLlaveAsync().Result;
                    if (!string.IsNullOrEmpty(llave)) StrCodDesEncriptado = client.desencriptarAESAsync(cod, llave).Result;
                    //int intIdUsu = int.Parse(StrCodDesEncriptado);
                    int intIdUsu = 3248;
                    using (WCFSeguridadUsuSisRolEntEstorgClient Seguridad = new WCFSeguridadUsuSisRolEntEstorgClient())
                    {
                        ResultadoUsuSisRolEstorg Usuario = Seguridad.listarUsuSisRolEntEstorg(new DatosUsuSisRolEstorg
                        {
                            IdSis = AppSettings.AppId,
                            IdUsu = intIdUsu,
                            FlgEst = 1,
                            Opr = "3",
                        });
                        if (Usuario != null)
                        {
                            if (Usuario.lstUsuSisRolEntEstorg != null)
                            {
                                userlogin = new UserLogin
                                {
                                    Codusuario = Usuario.lstUsuSisRolEntEstorg[0].IdUsu.ToString(),
                                    IdUsuario = Usuario.lstUsuSisRolEntEstorg[0].IdUsu,
                                    NameApellidos = Usuario.lstUsuSisRolEntEstorg[0].NomUsu,
                                    IdOficina = 0,
                                    DesOficina = "",
                                    IdPerfil = 0,
                                    Modulos = string.Empty
                                };
                                enAuditoria auditoriaModulo = await new CssApi().GetApi<enAuditoria>(new ApiParams
                                {
                                    EndPoint = AppSettings.baseUrlApi,
                                    Url = $"seguridad/modulos/listar/{intIdUsu}/{AppSettings.AppId}",
                                    UserAD = AppSettings.UserAD,
                                    PassAD = AppSettings.PassAD
                                });
                                if (auditoriaModulo != null)
                                {
                                    if (!auditoriaModulo.Rechazo)
                                    {
                                        if (auditoriaModulo.Objeto != null)
                                        {
                                            List<enModulos> Modulos = JsonConvert.DeserializeObject<List<enModulos>>(auditoriaModulo.Objeto.ToString());
                                            userlogin.Modulos = new CssUtil().traeListaOpcionesMenu(Modulos);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                if (userlogin != null)
                {
                    await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                    var identity = new Authentication().CreateIdentity(userlogin);
                    ClaimsPrincipal userPrincipal = new ClaimsPrincipal(identity);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, userPrincipal, new AuthenticationProperties
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

            //enAuditoria auditoria = new enAuditoria();
            //auditoria.Limpiar();

            //UserLogin userlogin = new UserLogin
            //{
            //    Codusuario = "IPEREZ",
            //    IdUsuario = 3248,
            //    NameApellidos = "IVAN PEREZ TINTAYA",
            //    IdOficina = 20,
            //    DesOficina = "MI CASA",
            //    IdPerfil = 2,
            //    Modulos = string.Empty, 
            //};
            //userlogin.token = CssToken.Generar(userlogin.IdUsuario.ToString());
            //try
            //{
            //    if (userlogin != null)
            //    {
            //        HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            //        var identity = new Authentication().CreateIdentity(userlogin);
            //        ClaimsPrincipal userPrincipal = new ClaimsPrincipal(identity);
            //        HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, userPrincipal, new AuthenticationProperties
            //        {
            //            ExpiresUtc = DateTime.Now.AddDays(1)
            //        });
            //        return RedirectToAction("Index", "Home");
            //    }
            //    else
            //    {
            //        return RedirectToAction("AccesoDenegado", "Authorization");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Log.Guardar(ex.Message.ToString());
            //    return RedirectToAction("AccesoDenegado", "Authorization");
            //}

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
