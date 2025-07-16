namespace LongDistanceService.Api.Services.Abstract;

public interface ITokenManager
{
    public string? RefreshToken { get; set; }
    public string? Token { get; set; }
}