using Microsoft.AspNetCore.Mvc;
using SCPOS.Models;
using SqlKata.Execution;

namespace SCPOS.Controllers; 

public class RuleBookViewComponent : ViewComponent{
    private readonly QueryFactory _queryFactory;
    public RuleBookViewComponent(QueryFactory queryFactory) {
        _queryFactory = queryFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync(int id, int windowId) {
        RuleBookViewModel viewModel =  _queryFactory.Query("Rulebook").Select("html").Where(new{Id = id}).First<RuleBookViewModel>();
        viewModel.currentPage = id;
        viewModel.maxPage = (await _queryFactory.Query("Rulebook").Select().GetAsync()).Count();
        viewModel.windowId = windowId;
        return View(viewModel);
    }
}