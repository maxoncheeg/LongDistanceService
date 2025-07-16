namespace LongDistanceService.Domain.Services.Options;

public class EmailOptions
{
    public string Email { get; set; } = string.Empty;
    public string Secret { get; set; } = string.Empty;
    public string Server { get; set; } = string.Empty;
    public int Port { get; set; }
    public int TimeoutInSeconds { get; set; } = 10;
}