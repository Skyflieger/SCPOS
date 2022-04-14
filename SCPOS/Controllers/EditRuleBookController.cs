using System.Security.Cryptography;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using SqlKata.Execution;

namespace SCPOS.Controllers; 

public class EditRuleBookController : Controller {

    private readonly QueryFactory _queryFactory;
    public EditRuleBookController(QueryFactory queryFactory) {
        _queryFactory = queryFactory;
    }
    
    [HttpPost]
    public Result EditRuleBook(string html, int id) {
        _queryFactory.Query("rulebook").Where(new{Id = id}).Update(new {
            html = html
        });
        
        return Result.Ok();
    }
    
    [HttpPost]
    public Result AddPage() {
        _queryFactory.Query("rulebook").Insert(new { html = "Page"});

        return Result.Ok();
    }
}