using System.Security.Cryptography;
using System.Text;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using SCPOS.Services;
using SqlKata;
using SqlKata.Execution;

namespace SCPOS.Controllers; 

public class AccountsController : Controller {

    private readonly QueryFactory _queryFactory;
    public AccountsController(QueryFactory queryFactory) {
        _queryFactory = queryFactory;
    }
    
    [HttpPost]
    public Result AddAccount(string username, string password) {
        _queryFactory.Query("account").Insert(new {
            Username = username,
            Password = Hash.GetHash(SHA256.Create(), password)
        });
        return Result.Ok();
    }
}