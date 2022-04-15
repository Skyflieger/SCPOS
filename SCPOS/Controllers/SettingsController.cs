using FluentResults;
using Microsoft.AspNetCore.Mvc;
using SCPOS.Models;
using SCPOS.Services;

namespace SCPOS.Controllers; 

public class SettingsController : Controller {

    [HttpPost]
    public Result SaveData() {
        return Result.Ok();
    }
}