using LongDistanceService.Data.Contexts.Abstract;
using LongDistanceService.Data.Entities.Identity;
using LongDistanceService.Domain.CQRS.Commands.Applications;
using LongDistanceService.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LongDistanceService.Data.Handlers.Commands.Applications;

public class ApplicationHandler(IApplicationDbContext context) : IRequestHandler<CreateApplicationRequest>, 
    IRequestHandler<FinishApplicationRequest>
{
    public async Task Handle(CreateApplicationRequest request, CancellationToken cancellationToken)
    {
        var application = new Application()
        {
            CreatorId = request.UserId,
            Created = DateOnly.FromDateTime(DateTime.Now)
        };
        var message = new ApplicationMessage()
        {
            Application = application,
            Text = request.Text,
            UserId = request.UserId,
            Timestamp = DateTime.UtcNow
        };
        
        await context.CreateAsync(application);
        await context.CreateAsync(message);

        await context.SaveAsync();
    }

    public async Task Handle(FinishApplicationRequest request, CancellationToken cancellationToken)
    {
        var application = await context.Applications.Where(a => a.Id == request.ApplicationId)
            .FirstAsync(cancellationToken: cancellationToken);
        
        application.Status = ApplicationState.Finished;
        
        context.Update(application);
        await context.SaveAsync();
    }
}