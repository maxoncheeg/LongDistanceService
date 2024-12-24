using LongDistanceService.Data.Contexts.Abstract;
using LongDistanceService.Domain.CQRS.Queries.Drivers;
using LongDistanceService.Domain.CQRS.Responses.Drivers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LongDistanceService.Data.Handlers.Queries.Drivers;

public class GetDriverHandler(IApplicationDbContext context)
    : IRequestHandler<GetDriversInfoRequest, IList<DriverInfoResponse>>,
        IRequestHandler<GetDriverRequest, DriverResponse?>
{
    private readonly Random _random = new Random();
    
    public async Task<IList<DriverInfoResponse>> Handle(GetDriversInfoRequest request,
        CancellationToken cancellationToken)
    {
        var drivers =
            context.Drivers.Include(d => d.Category);
        // todo: починить DRIVER IN WORK. RANDOM NOW

        return await drivers.Select(d => new DriverInfoResponse()
        {
            Id = d.Id,
            Experience = d.Experience,
            EmployeeNumber = d.EmployeeNumber,
            FullName = $"{d.Surname} {d.Name} {d.Patronymic}",
            InWork = _random.Next(50) < 24,
            CategoryName = d.Category.Name,
        }).Skip(request.Skip).Take(request.Take).ToListAsync(cancellationToken);
    }

    public async Task<DriverResponse?> Handle(GetDriverRequest request, CancellationToken cancellationToken)
    {
        var driver = await context.Drivers.Include(d => d.Category)
            .Where(d => d.Id == request.Id)
            .Select(d =>
                new DriverResponse()
                {
                    Id = d.Id,
                    Experience = d.Experience,
                    Name = d.Name,
                    Patronymic = d.Patronymic,
                    Surname = d.Surname,
                    EmployeeNumber = d.EmployeeNumber,
                    Class = d.Class,
                    BirthYear = d.BirthYear,
                    Category = new DriverCategoryResponse() { Id = d.CategoryId, Name = d.Category.Name }
                }).SingleOrDefaultAsync(cancellationToken);
        
        return driver;
    }
}