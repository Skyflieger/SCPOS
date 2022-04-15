using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using SCPOS.Models;
using SCPOS.Services;

namespace SCPOS.Controllers; 

public class AccountController : Controller {

    private readonly IAccountService _accountService;
    private readonly IUserClaimProvider _userClaimProvider;
    
    public AccountController(IAccountService accountService, IUserClaimProvider userClaimProvider) {
        _accountService = accountService;
        _userClaimProvider = userClaimProvider;
    }

    public IActionResult Login(string returnUrl = "/") {
        LoginModel objLoginModel = new() {
            ReturnUrl = returnUrl
        };
        return View(objLoginModel);
    }

    [HttpPost]
    public async Task<IActionResult> LogInAsync(LoginModel objLoginModel, CancellationToken cancellationToken = default) {
        if (!ModelState.IsValid) return View(objLoginModel);

        Account? user = _accountService.GetUser(objLoginModel.UserName, objLoginModel.Password);

        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, await _userClaimProvider.GetClaimsPrincipalFromUser(user, cancellationToken), new AuthenticationProperties {
            IsPersistent = objLoginModel.RememberLogin
        });
        
        return LocalRedirect(objLoginModel.ReturnUrl);

    }

    public async Task<IActionResult> LogOutAsync(CancellationToken cancellationToken = default) {
        
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        
        return LocalRedirect("/");
    }
}