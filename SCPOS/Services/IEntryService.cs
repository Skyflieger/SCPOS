using HtmlAgilityPack;

namespace SCPOS.Services; 

public interface IEntryService {
    public HtmlNode GetEntry(int id);
}