using Microsoft.AspNetCore.Mvc;
using SCPOS.Models;
using SqlKata.Execution;

namespace SCPOS.Controllers; 

public class AccountsViewComponent : ViewComponent{
    
    private readonly QueryFactory _queryFactory;
    public AccountsViewComponent(QueryFactory queryFactory) {
        _queryFactory = queryFactory;
    }
    
    public async Task<IViewComponentResult> InvokeAsync(int windowId) {
        AccountsViewModel viewModel = new() {
            Accounts = _queryFactory.Query("Account").Get<Account>().ToList(),
            WindowId = windowId
        };
        return View(viewModel);
    }
}