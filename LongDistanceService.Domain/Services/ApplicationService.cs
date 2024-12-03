using LongDistanceService.Domain.CQRS.Commands.Applications;
using LongDistanceService.Domain.CQRS.Queries.Applications;
using LongDistanceService.Domain.Models.Abstract;
using LongDistanceService.Domain.Services.Abstract;
using MediatR;

namespace LongDistanceService.Domain.Services;

public class ApplicationService(IMediator mediator) : IApplicationService
{
    public async Task CreateApplicationAsync(int userId, string firstMessageText)
    {
        await mediator.Send(new CreateApplicationRequest(userId, firstMessageText));
    }

    public async Task<IList<IApplicationInfo>> GetApplicationInfoAsync()
    {
        return new List<IApplicationInfo>();
    }

    public async Task<IList<IApplicationInfo>> GetApplicationInfoAsync(int userId)
    {
        var infos = await mediator.Send(new GetApplicationsInfoRequest(userId));
        return new List<IApplicationInfo>(infos);
    }

    public async Task<IApplication?> GetApplicationWithMessagesAsync(int applicationId)
    {
        var application = await mediator.Send(new GetApplicationWithMessagesRequest(applicationId));
        return application;
    }

    public async Task SendMessageAsync(int applicationId, int userId, string text, int? answeredAt = null)
    {
        await mediator.Send(new SendApplicationMessageRequest(userId, applicationId, text, answeredAt));
    }

    public async Task FinishApplicationAsync(int applicationId)
    {
        await mediator.Send(new FinishApplicationRequest(applicationId));
    }
}