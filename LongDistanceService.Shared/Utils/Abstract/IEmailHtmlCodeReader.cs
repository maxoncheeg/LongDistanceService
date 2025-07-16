using LongDistanceService.Domain.Enums;

namespace LongDistanceService.Shared.Utils.Abstract;

public interface IEmailHtmlCodeReader
{
    public Dictionary<CodeReason, Func<string, string>> ReadAndParseHtmlTemplates(string directory);
}