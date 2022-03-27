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
}