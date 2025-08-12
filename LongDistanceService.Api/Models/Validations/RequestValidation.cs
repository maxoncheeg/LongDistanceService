namespace LongDistanceService.Api.Models.Validations;

public class RequestValidation
{
    public bool Result { get; set; }
    public string Message { get; set; } = string.Empty;
    public int Code { get; set; }
}