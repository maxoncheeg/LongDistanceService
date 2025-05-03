using LongDistanceService.Domain.Models.Abstract;
using LongDistanceService.Domain.Models.Abstract.Applications;

namespace LongDistanceService.Domain.Services.Abstract;

public interface IApplicationService
{
    public Task CreateApplicationAsync(int userId, string firstMessageText);
    public Task<IList<IApplicationInfo>> GetApplicationInfoAsync();
    public Task<IList<IApplicationInfo>> GetApplicationInfoAsync(int userId);
    public Task<IApplication?> GetApplicationWithMessagesAsync(int applicationId);
    public Task SendMessageAsync(int applicationId, int userId, string text, int? answeredAt = null);
    public Task FinishApplicationAsync(int applicationId);
}