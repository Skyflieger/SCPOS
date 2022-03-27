using Microsoft.AspNetCore.Html;

namespace SCPOS.Models; 

public class WindowViewModel {
    public string? Title { get; set; }
    public int Id { get; set; }
    public string? ContentViewComponent { get; set; }
    public string? ViewData { get; set; }
}