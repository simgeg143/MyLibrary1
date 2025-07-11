using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace MyLibrary1.Helpers
{
    public class TokenHelper
    {
        public static string GetRoleFromToken(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token);
            var roleClaim = jwtToken.Claims.FirstOrDefault(c => 
            c.Type == "role" ||
            c.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role" ||
            c.Type == ClaimTypes.Role);
            return roleClaim?.Value;
        }
        public static string GetUsernameFromToken(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token);
            var nameClaim = jwtToken.Claims.FirstOrDefault(c =>
            c.Type == "name" ||
            c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name" ||
            c.Type == ClaimTypes.Role); 
       
            return nameClaim?.Value;
        }
    }
}
