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
            identity.AddClaim(new Claim("Modulos", user.Modulos));
            //identity.AddClaim(new Claim("Token", user.token));
            return identity;
        }

    }
}
