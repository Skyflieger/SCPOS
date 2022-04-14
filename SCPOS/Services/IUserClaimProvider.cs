using System.Security.Claims;
using SCPOS.Models;

namespace SCPOS.Services; 

public interface IUserClaimProvider { 
    Task<ClaimsPrincipal> GetClaimsPrincipalFromUser(Account user, CancellationToken cancellationToken = default);
}