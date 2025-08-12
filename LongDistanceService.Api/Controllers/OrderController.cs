using LongDistanceService.Api.Controllers.Abstract;
using LongDistanceService.Api.Controllers.Routes;
using LongDistanceService.Api.Services.Abstract;
using LongDistanceService.Domain.Services.Entities.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LongDistanceService.Api.Controllers;

public class OrderController(
    ISecurityService securityService,
    IOrderService orderService) : AbstractController
{
    [Authorize]
    [HttpGet(ServiceRoutes.Order.Base)]
    public async Task<IActionResult> GetSlimOrders(int skip = 0, int take = 5)
    {
        var validation = ValidateGetRequestPagination(skip, take);
        if (!validation.Result) return BaseResponse(validation.Code, null, validation.Message);

        var user = await securityService.GetCurrentUserAsync();

        if (user == null)
            return BaseResponse(StatusCodes.Status401Unauthorized);

        var profile = await orderService.GetSlimOrders(user.Id, skip, take);

        return BaseResponse(StatusCodes.Status200OK, profile);
    }
}