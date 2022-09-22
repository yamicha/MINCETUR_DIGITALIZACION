using System;
using System.Security.Claims;
using EnServiciosDigitalizacion;
using Microsoft.Owin.Security;
namespace Utilitarios.Helpers.Authorization
{
    public class AuthenticationService
    {
        private readonly IAuthenticationManager _authenticationManager;
        public AuthenticationService(IAuthenticationManager authenticationManager)
        {
            _authenticationManager = authenticationManager; 
        }
        public enAuditoria SignIn(string username, string password, bool isPersistent)
        {
            enAuditoria auditoria = new enAuditoria();
            auditoria.Limpiar(); 
            UserLogin userPrincipal = null;  
            bool isAuthenticated = false;
            try
            {
                // service login 
                //userPrincipal = _sWLogin.UsuarioActiveDirectory_Login2(username);
                userPrincipal = new UserLogin()
                {
                    IdOficina = 2,
                    IdUsuario = 25,
                    DesOficina = "OFICINA CENTRAL",
                    NameApellidos = "IVAN PEREZ TINTAYA",
                    Codusuario = "Iperez"
                }; 
                if (userPrincipal != null)
                    isAuthenticated = userPrincipal.Usuario_Valido;
            }
            catch (Exception)
            {
                isAuthenticated = false;
                userPrincipal = null;
            }
            if (userPrincipal == null)
                auditoria.Rechazar("El usuario no existe");

            if (!isAuthenticated)
                auditoria.Rechazar("Usuario o contraseña incorrecto");
            var identity = CreateIdentity(userPrincipal);
            _authenticationManager.SignOut(AppAuthenticationType.ApplicationCookie);
            if (isPersistent)
                _authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = true }, identity);
            else
                _authenticationManager.SignIn(new AuthenticationProperties { IsPersistent = true, ExpiresUtc = DateTimeOffset.UtcNow.AddDays(1) }, identity);
            return auditoria;
        }

        private ClaimsIdentity CreateIdentity(UserLogin userPrincipal)
        {
            var identity = new ClaimsIdentity(AppAuthenticationType.ApplicationCookie, ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            identity.AddClaim(new Claim("http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider", "ExternalCookie"));
            identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, userPrincipal.IdUsuario.ToString()));
            identity.AddClaim(new Claim(ClaimTypes.WindowsAccountName, userPrincipal.Codusuario));
            identity.AddClaim(new Claim("NamesSurnames", userPrincipal.NameApellidos));
            identity.AddClaim(new Claim("NameOffice", userPrincipal.DesOficina));
            identity.AddClaim(new Claim("IdPerfil", userPrincipal.IdPerfil.ToString()));
            identity.AddClaim(new Claim("IdOficina", userPrincipal.IdOficina.ToString()));
            return identity;
        }

    }
}
