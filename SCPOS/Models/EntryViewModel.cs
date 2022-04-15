using HtmlAgilityPack;

namespace SCPOS.Models; 

public class EntryViewModel {
    public int Id { get; set; }
    public HtmlNode? Content { get; set; }
}