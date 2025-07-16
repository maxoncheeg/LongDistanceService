using LongDistanceService.Data.Contexts.Abstract;
using LongDistanceService.Data.Entities.Identity;
using LongDistanceService.Domain.CQRS.Commands.Applications;
using MediatR;

namespace LongDistanceService.Data.Handlers.Commands.Applications;

public class ApplicationMessagesHandler(IApplicationDbContext context) : IRequestHandler<SendApplicationMessageRequest>
{
    public async Task Handle(SendApplicationMessageRequest request, CancellationToken cancellationToken)
    {
        var message = new ApplicationMessage()
        {
            ApplicationId = request.ApplicationId,
            AnsweredAt = request.AnsweredAt,
            Text = request.Text,
            UserId = request.UserId,
            Timestamp = DateTime.UtcNow
        };
        
        await context.CreateAsync(message);

        await context.SaveAsync();
    }
}