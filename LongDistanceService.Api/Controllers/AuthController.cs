using LongDistanceService.Api.Controllers.Abstract;
using LongDistanceService.Api.Controllers.Routes;
using Microsoft.AspNetCore.Mvc;

namespace LongDistanceService.Api.Controllers;

public class AuthController : AbstractController
{
    
    /// <summary>
    /// Аутентификация пользователя в LDS
    /// </summary>
    /// <returns></returns>
    [HttpPost(ServiceRoutes.Auth.Login)]
    public async Task<IActionResult> Login()
    {
        return BaseResponse(StatusCodes.Status200OK, null);
    }
}