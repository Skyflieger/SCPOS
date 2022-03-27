using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using Microsoft.AspNetCore.Mvc;
using SCPOS.Models;

namespace SCPOS.Controllers; 

public class WindowViewComponent : ViewComponent {
    public async Task<IViewComponentResult> InvokeAsync(int id, string title) {
        
        
        WindowViewModel model = new WindowViewModel {
            Id = id,
            Title = title,
            ContentViewComponent = "Database"
        };
        return View(model);
    }
    

}