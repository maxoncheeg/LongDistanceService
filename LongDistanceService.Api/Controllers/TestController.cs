using System.Diagnostics;
using LongDistanceService.Api.Controllers.Abstract;
using LongDistanceService.Api.Controllers.Routes;
using LongDistanceService.Domain.Services.Abstract;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LongDistanceService.Api.Controllers;

public class SlimTestTruck
{
    public int Id { get; set; }
    public string BrandAndModel { get; set; }
    public string Image { get; set; }
}


public class TestController(IVehicleService vehicleService) : AbstractController
{
    private static readonly ActivitySource ActivitySource = new("TestController");
    
    private Random _random = new Random();

    [HttpGet(ServiceRoutes.Test.Base)]
    public IActionResult Index()
    {
        return BaseResponse(200, "test");
    }


    [HttpGet(ServiceRoutes.Test.GetRandomNumber)]
    public async Task<IActionResult> GetRandomNumberAsync()
    {
        return BaseResponse(200,  _random.Next(1, 1000));
    }

    [HttpGet(ServiceRoutes.Test.GetAgeByYear)]
    public async Task<IActionResult> GetAgeByYearAsync(string year)
    {
        if (!int.TryParse(year, out int result))
        {
            return BaseResponse(StatusCodes.Status400BadRequest, false, null);
        }

        using var activity = ActivitySource.StartActivity("PossibleTimeLoss", ActivityKind.Server);
        if (activity != null)
        {
            activity.Start();
            await Task.Delay(400);
            activity.Stop();
        }

        return BaseResponse(200, "примерна: " + (DateTime.Now.Year - result));
    }

    [HttpGet(ServiceRoutes.Test.GetTestTrucks)]
    public async Task<IActionResult> GetTestTrucks([FromQuery]string take, [FromQuery]string skip)
    {
        int.TryParse(take, out var takeNumber);
        int.TryParse(skip, out var skipNumber);
        
        if (takeNumber <= 0)
            takeNumber = 30;
        if (skipNumber < 0)
            skipNumber = 0;
        
        var vehicles = await vehicleService.GetVehiclesAsync(takeNumber, skipNumber);
        var testTrucks = vehicles.Select(v => new SlimTestTruck()
        {
            Id = v.Id,
            Image = v.ImagePath ?? "none",
            BrandAndModel = v.BrandAndModel
        }).ToList();
        
        return BaseResponse(StatusCodes.Status200OK, testTrucks);
    }
    
    [HttpGet(ServiceRoutes.Test.GetTestTruckById)]
    public async Task<IActionResult> GetTestTrucks(int id)
    {
        var vehicle = await vehicleService.GetVehicleAsync(id);
        
        
        if(vehicle == null)
            return BaseResponse(StatusCodes.Status404NotFound, null, "resource not found");
        else
        {
            var obj = new
            {
                vehicle.Id,
                Image = vehicle.ImagePath ?? "none",
                Brand = vehicle.Model.Brand.Name,
                Model = vehicle.Model.Name,
                vehicle.Year,
                vehicle.LicensePlate,
            };
            
            return BaseResponse(StatusCodes.Status200OK, obj);
        }
    }
    
    [HttpPost(ServiceRoutes.Test.CreateTestTruck)]
    public async Task<IActionResult> GetTestTrucks([FromBody] SlimTestTruck truck)
    {
        return BaseResponse(StatusCodes.Status200OK, null);
    }
}