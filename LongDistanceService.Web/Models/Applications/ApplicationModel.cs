using System.ComponentModel.DataAnnotations;

namespace LongDistanceService.Web.Models.Applications;

public class ApplicationModel
{
    [MaxLength(512)]
    public string Text { get; set; } = string.Empty;
}