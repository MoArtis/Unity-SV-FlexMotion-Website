using System.Xml.Linq;

public class CalloutShortCode : SyncShortcode
{
    private const string Type = nameof(Type);
    private const string Title = nameof(Title);
    
    public override ShortcodeResult Execute(KeyValuePair<string, string>[] args, string content, IDocument document, IExecutionContext context)
    {
        var dictionary = args.ToDictionary(Type, Title);

        var div = new XElement(
            "div",
            new XAttribute("Class", $"callout callout-{dictionary[Type]}"), 
            content);
        
        var title = dictionary.GetString(Title);
        if (!string.IsNullOrWhiteSpace(title))
        {
            div.AddFirst(new XElement("h4", title));
        }
        
        return div.ToString();
    }
}