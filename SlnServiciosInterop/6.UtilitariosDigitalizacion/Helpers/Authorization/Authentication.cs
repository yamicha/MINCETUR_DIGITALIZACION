using System;
using System.Security.Claims;
using System.Threading.Tasks;
using EnServiciosDigitalizacion;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc; 

namespace Utilitarios.Helpers.Authorization
{
    public class Authentication
    {
  
        //public async Task<enAuditoria> SignIn(UserLogin userlogin)
        //{
        //    enAuditoria auditoria = new enAuditoria();
        //    auditoria.Limpiar(); 
        //    bool isAuthenticated = false;
        //    try
        //    {
        //        if (userlogin != null)
        //            isAuthenticated = userlogin.Usuario_Valido;
        //    }
        //    catch (Exception)
        //    {
        //        isAuthenticated = false;
        //        userlogin = null;
        //    }
        //    if (userlogin == null)
        //        auditoria.Rechazar("El usuario no existe");

        //    if (!isAuthenticated)
        //        auditoria.Rechazar("Usuario o contraseña incorrecto");
        //    ClaimsIdentity identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);
        //   var userPrincipal = CreateIdentity(userlogin);

        //    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, userPrincipal, new AuthenticationProperties
        //    {
        //        ExpiresUtc = DateTime.Now.AddMinutes(1)
        //    });
        //    return auditoria;
        //}

        public ClaimsIdentity CreateIdentity(UserLogin user)
        {
            ClaimsIdentity identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);
            //var identity = new ClaimsIdentity(AppAuthenticationType.ApplicationCookie, ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            identity.AddClaim(new Claim(ClaimTypes.Name, user.Codusuario));
            identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.IdUsuario.ToString()));
            identity.AddClaim(new Claim(ClaimTypes.Surname, user.NameApellidos));
            identity.AddClaim(new Claim("Office", user.DesOficina));
            identity.AddClaim(new Claim("IdPerfil", user.IdPerfil.ToString()));
            identity.AddClaim(new Claim("IdOficina", user.IdOficina.ToString()));
            identity.AddClaim(new Claim("Token", user.token));
            return identity;
        }

    }
}
