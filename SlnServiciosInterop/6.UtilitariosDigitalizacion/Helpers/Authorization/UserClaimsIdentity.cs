using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Http;

namespace Utilitarios.Helpers.Authorization
{
    public class UserClaimsIdentity
    {
        private static IHttpContextAccessor _httpContextAccessor;
        public UserClaimsIdentity(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        /// <summary>
        /// Id del usuario autentificado.
        /// </summary>
        /// <returns></returns>
        public static string GetUserId
            => GetClaimsIdentity()
            .Where(c => c.Type == ClaimTypes.NameIdentifier)
            .Select(c => c.Value)
            .FirstOrDefault();

        /// <summary>
        /// Obtiene el user login
        /// </summary>
        /// <returns></returns>
        public static string GetUserLogin
            => GetClaimsIdentity()
            .Where(c => c.Type == ClaimTypes.WindowsAccountName)
            .Select(c => c.Value)
            .FirstOrDefault();

        /// <summary>
        /// Obtiene el nombre del ususrio autentificado.
        /// </summary>
        /// <returns></returns>
        //public static string GetUserCode
        //  => _httpContextAccessor.HttpContext.User.Identity.NameIdentifier; 

        /// <summary>
        /// Obtiene el departamento u oficina donde labora el usuario autentificado.
        /// </summary>
        /// <returns></returns>
        public static string GetUserDepartment
            => GetClaimsIdentity()
            .Where(c => c.Type == "Office")
            .Select(c => c.Value)
            .FirstOrDefault();

        /// <summary>
        /// Obtiene el sub-departamento donde labora el usuario autentificado.
        /// </summary>
        /// <returns></returns>
        public static string GetUserSubDepartment
            => GetClaimsIdentity()
            .Where(c => c.Type == "SubOffice")
            .Select(c => c.Value)
            .FirstOrDefault();

        /// <summary>
        /// Obtiene el email del usuario autentificado.
        /// </summary>
        /// <returns></returns>
        public static string GetUserEmailAddress
            => GetClaimsIdentity()
            .Where(c => c.Type == ClaimTypes.Email)
            .Select(c => c.Value)
            .FirstOrDefault();

        /// <summary>
        /// Obtiene el rol del usuario autentificado.
        /// </summary>
        /// <returns></returns>
        public static string GetUserRol
            => GetClaimsIdentity()
            .Where(c => c.Type == ClaimTypes.Role)
            .Select(c => c.Value)
            .FirstOrDefault();

        /// <summary>
        /// Obtiene el Token Externo de acceso al sistema 
        /// </summary>
        /// <returns></returns>
        public static string GetExternalAccessToken
            => GetClaimsIdentity()
            .Where(c => c.Type == "ExternalAccessToken")
            .Select(c => c.Value)
            .FirstOrDefault();

        /// <summary>
        /// Obtiene el sub-departamento donde labora el usuario autentificado.
        /// </summary>
        /// <returns></returns>
        public static string GetUserNroDocument
            => GetClaimsIdentity()
            .Where(c => c.Type == "PersonNroDoc")
            .Select(c => c.Value)
            .FirstOrDefault();

        /// <summary>
        /// Obtiene el sub-departamento donde labora el usuario autentificado.
        /// </summary>
        /// <returns></returns>
        public static string GetUserTypeDocument
            => GetClaimsIdentity()
            .Where(c => c.Type == "PersonTypeDoc")
            .Select(c => c.Value)
            .FirstOrDefault();

        /// <summary>
        /// Obtiene el Id del titular de SIDEMCAT.
        /// </summary>
        /// <returns></returns>
        public static string GetTitularIdSIDEMCAT
            => GetClaimsIdentity()
            .Where(c => c.Type == "TitularIdSIDEMCAT")
            .Select(c => c.Value)
            .FirstOrDefault();

        /// <summary>
        /// Obtiene el Tipo del titular de SIDEMCAT (J o N).
        /// </summary>
        /// <returns></returns>
        public static string GetTitularTipoSIDEMCAT
            => GetClaimsIdentity()
            .Where(c => c.Type == "TitularTipoSIDEMCAT")
            .Select(c => c.Value)
            .FirstOrDefault();

     

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Claim> GetClaimsIdentity()
        {
            var identity = (ClaimsIdentity)_httpContextAccessor.HttpContext.User.Identity;
            IEnumerable<Claim> claims = identity.Claims;
            return claims;
        }
    }
}
