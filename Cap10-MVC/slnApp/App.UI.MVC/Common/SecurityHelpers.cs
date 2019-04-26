using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace App.UI.MVC.Common
{
    public class SecurityHelpers
    {
        public static IEnumerable<Claim> GetClaimsByType(string type)
        {
            var idenitity = (ClaimsIdentity)HttpContext.Current.User.Identity;
            var claims = idenitity.Claims.Where(item => item.Type == type).ToList();
            return claims;
        }

        public static string GetUserFullName()
        {
            var claimValue = GetClaimsByType(ClaimTypes.Name).FirstOrDefault()?.Value;
            return claimValue;
        }

        public static int GetUserID()
        {
            var claimValue = GetClaimsByType("UsuarioID").FirstOrDefault() !=null ?
                int.Parse(GetClaimsByType("UsuarioID").FirstOrDefault().Value) : 0;
            return claimValue;
        }

        public static bool IsLogged()
        {
            return HttpContext.Current.User.Identity.IsAuthenticated;
        }

        public static bool IsAdmin()
        {
            return HttpContext.Current.User.IsInRole("admin");
        }
        public static bool IsSupervisor()
        {
            return HttpContext.Current.User.IsInRole("supervisor");
        }

    }
}