using LongDistanceService.Data.Contexts.Abstract;
using LongDistanceService.Domain.CQRS.Queries.Vehicles;
using LongDistanceService.Domain.CQRS.Responses.Cargoes;
using LongDistanceService.Domain.CQRS.Responses.Vehicles;
using LongDistanceService.Domain.Models.Abstract.Cargoes;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LongDistanceService.Data.Handlers.Queries.Vehicles;

public class GetVehicleHandler(IApplicationDbContext context)
    : IRequestHandler<GetVehiclesInfoRequest, IList<VehicleInfoResponse>>,
        IRequestHandler<GetVehicleRequest, VehicleResponse?>
{
    public async Task<IList<VehicleInfoResponse>> Handle(GetVehiclesInfoRequest request,
        CancellationToken cancellationToken)
    {
        var vehicles = context.Vehicles
            .Include(v => v.Model)
            .ThenInclude(m => m.Brand)
            .Select(v => new VehicleInfoResponse(v.Id, $"{v.Model.Brand.Name} {v.Model.Name}, {v.Year}", v.LicensePlate,
                v.ImagePath));

        return await vehicles.Skip(request.Skip).Take(request.Take).ToListAsync(cancellationToken);
    }

    public async Task<VehicleResponse?> Handle(GetVehicleRequest request, CancellationToken cancellationToken)
    {
        var vehicle = context.Vehicles.Where(v => v.Id == request.Id);
        var joinedVehicle = vehicle.Include(v => v.Model)
            .ThenInclude(m => m.Brand)
            .Include(v => v.VehicleCargoCategories)
            .ThenInclude(c => c.Category).ThenInclude(c => c.Unit);

        var selectedVehicle = joinedVehicle.Select(v => new VehicleResponse()
        {
            Id = v.Id,
            Kilometerage = v.Kilometerage,
            LicensePlate = v.LicensePlate,
            Year = v.Year,
            OverhaulYear = v.OverhaulYear,
            ImagePath = v.ImagePath,
            Model = new ModelResponse()
            {
                Id = v.Model.Id, Name = v.Model.Name,
                Brand = new BrandResponse() { Id = v.Model.Brand.Id, Name = v.Model.Brand.Name }
            },
            CargoCategories = new List<ICargoCategory>(v.VehicleCargoCategories.Select(c => new CargoCategoryResponse
            {
                Id = c.Category.Id,
                Unit = new UnitResponse
                {
                    Id = c.Category.Unit.Id,
                    Name = c.Category.Unit.Name
                },
                Name = c.Category.Name
            }).ToList())
        });

        return await selectedVehicle.FirstOrDefaultAsync(cancellationToken);
    }
}