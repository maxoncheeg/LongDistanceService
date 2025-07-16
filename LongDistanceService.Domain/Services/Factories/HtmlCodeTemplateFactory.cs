using LongDistanceService.Domain.Enums;
using LongDistanceService.Domain.Services.Factories.Abstract;

namespace LongDistanceService.Domain.Services.Factories;

public class HtmlCodeTemplateFactory(Dictionary<CodeReason, Func<string, string>> templates) : IHtmlCodeTemplateFactory
{
    public string GetHtmlByReason(CodeReason codeReason, string code)
    {
        if (templates.TryGetValue(codeReason, out var template))
            return template(code);
        
        if(templates.TryGetValue(CodeReason.Default, out var defaultTemplate))
            return defaultTemplate(code);

        return code;
    }
}