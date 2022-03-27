using Microsoft.AspNetCore.Mvc;
using SCPOS.Models;

namespace SCPOS.Controllers; 

public class DatabaseViewComponent : ViewComponent {
    public async Task<IViewComponentResult> InvokeAsync(int windowId) {
        DatabaseViewModel viewModel = new DatabaseViewModel {WindowId = windowId};
        return View(viewModel);
    }
}