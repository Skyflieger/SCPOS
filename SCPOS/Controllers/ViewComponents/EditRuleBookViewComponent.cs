using System.Data;
using Microsoft.AspNetCore.Mvc;
using SCPOS.Models;
using SqlKata.Execution;

namespace SCPOS.Controllers; 

public class EditRuleBookViewComponent : ViewComponent {

    private readonly QueryFactory _queryFactory;
    public EditRuleBookViewComponent(QueryFactory queryFactory) {
        _queryFactory = queryFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync(int id, int windowId) {
        RuleBookViewModel viewModel =  _queryFactory.Query("rulebook").Select("html").Where(new{Id = id}).First<RuleBookViewModel>();
        viewModel.currentPage = id;
        viewModel.maxPage = (await _queryFactory.Query("rulebook").Select().GetAsync()).Count();
        return View(viewModel);
    }
}