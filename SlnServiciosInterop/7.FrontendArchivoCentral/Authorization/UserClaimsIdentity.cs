using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace Frotend.ArchivoCentral.Micetur.Authorization
{
    public static class ClaimsPrincipalExtensions
    {
        public static string GetUserIdOffice(this ClaimsPrincipal claimsPrincipal)
                => claimsPrincipal.FindFirst("IdOficina").Value;

        public static string GetCodUsuario(this ClaimsPrincipal claimsPrincipal)
                => claimsPrincipal.FindFirst(ClaimTypes.Name).Value;

        public static string GetUserName(this ClaimsPrincipal claimsPrincipal)
                => claimsPrincipal.FindFirst(ClaimTypes.Surname).Value;

        public static string GetOffice(this ClaimsPrincipal claimsPrincipal)
                => claimsPrincipal.FindFirst("Office").Value;

        public static string GetUserId(this ClaimsPrincipal claimsPrincipal)
               => claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier).Value;

        public static string GetUserIdPerfil(this ClaimsPrincipal claimsPrincipal)
       => claimsPrincipal.FindFirst("IdPerfil").Value;

        public static string GetUserToken(this ClaimsPrincipal claimsPrincipal)
        => claimsPrincipal.FindFirst("Token").Value;

    }
}
