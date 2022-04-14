namespace SCPOS.Models; 

public class RuleBookViewModel {
    public int currentPage { get; set; }
    public int maxPage { get; set; }
    public string? html { get; set; }
    public int windowId { get; set; }
}