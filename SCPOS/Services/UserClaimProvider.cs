using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using SCPOS.Models;

namespace SCPOS.Services; 

public class UserClaimProvider : IUserClaimProvider {
    public async Task<ClaimsPrincipal> GetClaimsPrincipalFromUser(Account user, CancellationToken cancellationToken = default) {
        
        List<Claim> claims = new() {
            new Claim(ClaimTypes.NameIdentifier, Convert.ToString(user.Id)),
            new Claim(ClaimTypes.Name, user.Username)
        };
        
        ClaimsIdentity identity = new(claims, CookieAuthenticationDefaults.AuthenticationScheme);

        return new ClaimsPrincipal(identity);
    }
}