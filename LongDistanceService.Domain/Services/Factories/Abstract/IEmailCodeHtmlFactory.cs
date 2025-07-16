using LongDistanceService.Domain.Enums;

namespace LongDistanceService.Domain.Services.Factories.Abstract;

public interface IHtmlCodeTemplateFactory
{
    public string GetHtmlByReason(CodeReason codeReason, string code);
}