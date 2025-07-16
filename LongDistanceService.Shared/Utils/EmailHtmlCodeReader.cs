using LongDistanceService.Domain.Enums;
using LongDistanceService.Shared.Utils.Abstract;

namespace LongDistanceService.Shared.Utils;

public class EmailHtmlCodeReader : IEmailHtmlCodeReader
{
    private const string CodePlaceTag = "$$CODE$$";

    public Dictionary<CodeReason, Func<string, string>> ReadAndParseHtmlTemplates(string directory)
    {
        int index = 0;
        Dictionary<CodeReason, Func<string, string>> result = [];

        while (Enum.IsDefined(typeof(CodeReason), index))
        {
            int currentIndex = index++;
            string filePath = Path.Join(directory, $"{(CodeReason)currentIndex}.html");

            if (!File.Exists(filePath)) continue;
            var text = File.ReadAllText(filePath);

            var codeIndex = text.IndexOf(CodePlaceTag, 0, StringComparison.OrdinalIgnoreCase);

            if (codeIndex == -1)
                continue;

            result.Add((CodeReason)currentIndex, Function);
            continue;

            string Function(string code) => text[..codeIndex] + code + text[(codeIndex + CodePlaceTag.Length)..];
        }

        return result;
    }
}