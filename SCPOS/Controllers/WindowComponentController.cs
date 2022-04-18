using Microsoft.AspNetCore.Mvc;

namespace SCPOS.Controllers; 

public class WindowComponentController : Controller {
    public IActionResult Database(int windowId)
    {
        return ViewComponent("Database", new{ windowId = windowId});
    }
    
    public IActionResult Entry(int id)
    {
        return ViewComponent("Entry", new {id = id});
    }
    
    public IActionResult Settings(int windowId)
    {
        return ViewComponent("Settings", new{ windowId = windowId});
    }
    
    public IActionResult Accounts(int windowId)
    {
        return ViewComponent("Accounts", new{ windowId = windowId});
    }
    public IActionResult EditRuleBook(int id, int windowId) {
        if (id == 0)
            id = 1;
        return ViewComponent("EditRuleBook", new{ Id = id, windowId = windowId});
    }
    public IActionResult RuleBook(int id, int windowId) {
        if (id == 0)
            id = 1;
        return ViewComponent("RuleBook", new{ id = id, windowId = windowId});
    }
}