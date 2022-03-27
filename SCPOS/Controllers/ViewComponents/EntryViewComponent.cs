using Microsoft.AspNetCore.Mvc;
using SCPOS.Models;
using SCPOS.Services;

namespace SCPOS.Controllers; 

public class EntryViewComponent : ViewComponent {

    private readonly IEntryService _entryService;
    public EntryViewComponent(IEntryService entryService) {
        _entryService = entryService;
    }
    public async Task<IViewComponentResult> InvokeAsync(int id) {
        EntryViewModel viewModel = new EntryViewModel {
            Id = id,
            Content = _entryService.GetEntry(id)
        };
        return View(viewModel);
    }
    

}