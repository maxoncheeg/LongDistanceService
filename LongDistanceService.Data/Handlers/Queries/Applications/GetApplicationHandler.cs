using LongDistanceService.Data.Contexts.Abstract;
using LongDistanceService.Domain.CQRS.Queries.Applications;
using LongDistanceService.Domain.CQRS.Responses.Applications;
using LongDistanceService.Domain.Models.Abstract;
using LongDistanceService.Domain.Models.Abstract.Applications;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LongDistanceService.Data.Handlers.Queries.Applications;

public class GetApplicationHandler(IApplicationDbContext context)
    : IRequestHandler<GetApplicationsInfoRequest, IList<ApplicationInfoResponse>>,
        IRequestHandler<GetApplicationWithMessagesRequest, ApplicationResponse?>
{
    public async Task<IList<ApplicationInfoResponse>> Handle(GetApplicationsInfoRequest request,
        CancellationToken cancellationToken)
    {
        var result = context.Applications.Where(a => a.CreatorId == request.UserId).Include(a => a.Messages)
            .Skip(request.Skip)
            .Take(request.Take).Select(a =>
                new ApplicationInfoResponse(a.Id, a.Created,
                    a.Messages.OrderByDescending(m => m.Timestamp).FirstOrDefault()!.Timestamp,
                    a.Status));

        return await result.ToListAsync(cancellationToken);
    }

    public async Task<ApplicationResponse?> Handle(GetApplicationWithMessagesRequest request,
        CancellationToken cancellationToken)
    {
        var result = context.Applications.Where(a => a.Id == request.ApplicationId)
            .Include(a => a.Messages)
            .Select(a =>
                new ApplicationResponse(a.Id, a.Created, a.Status, a.CreatorId,
                    new List<IApplicationMessage>(a.Messages.Select(m =>
                        new ApplicationMessageResponse(m.Id, m.ApplicationId, m.UserId, m.AnsweredAt, m.Text,
                            m.Timestamp)))
                ));

        return await result.FirstOrDefaultAsync(cancellationToken);
    }
}