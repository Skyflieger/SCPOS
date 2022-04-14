using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using SCPOS.Models;

namespace SCPOS.Controllers; 

public class SettingsViewComponent : ViewComponent {
    public async Task<IViewComponentResult> InvokeAsync(int windowId) {
        SettingsViewModel viewModel = new() {
        };
        return View(viewModel);
    }
}