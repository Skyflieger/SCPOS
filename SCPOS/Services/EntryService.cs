using System.Net;
using Microsoft.AspNetCore.Html;
using HtmlAgilityPack;

namespace SCPOS.Services; 

public class EntryService : IEntryService{
    public HtmlNode GetEntry(int id) {
        string idString = id.ToString("000");
        string url = "https://scp-wiki.wikidot.com/scp-" + idString;
        
        var data = new WebClient().DownloadString(url);
        var doc = new HtmlDocument();
        doc.LoadHtml(data);

        List<HtmlNode> nodesToRemove = new List<HtmlNode>();

        try {
            nodesToRemove.AddRange(doc.DocumentNode
                .SelectNodes("//div[@class='page-rate-widget-box']")
                .ToList());
        }
        catch (Exception e) {
        }

        try {
            nodesToRemove.AddRange(doc.DocumentNode
                .SelectNodes("//div[@class='footer-wikiwalk-nav']")
                .ToList());
        }
        catch (Exception e) {
        }

        foreach (HtmlNode toRemove in nodesToRemove)
            toRemove.Remove();
        
        
        HtmlNode node = doc.GetElementbyId("page-content");

        return node;
    }
}