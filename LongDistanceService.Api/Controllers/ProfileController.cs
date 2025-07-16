using LongDistanceService.Api.Controllers.Abstract;
using LongDistanceService.Api.Controllers.Routes;
using LongDistanceService.Api.Services.Abstract;
using LongDistanceService.Domain.Enums;
using LongDistanceService.Domain.Services.Entities.Abstract;
using LongDistanceService.Domain.Services.Identity.Abstract;
using LongDistanceService.Domain.Services.Utils.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace LongDistanceService.Api.Controllers;

public class ProfileController(
    IEmailSender emailSender,
    ISecurityService securityService,
    ITwoFactorCodeService codeService,
    IUserService userService) : AbstractController
{
    [HttpPost(ServiceRoutes.Profile.Email)]
    public async Task<IActionResult> SendEmailVerificationCode()
    {
        var user = await securityService.GetCurrentUserAsync();

        if (user == null)
            return BaseResponse(StatusCodes.Status401Unauthorized, null, "User is not logged in");

        if (user.IsEmailVerified)
            return BaseResponse(StatusCodes.Status400BadRequest, null, "Email is already verified");

        var code = await codeService.GenerateTwoFactorCodeAsync(user.Id, CodeReason.ConfirmEmail);

        if (code == null)
            return BaseResponse(StatusCodes.Status400BadRequest, null, "Cannot generate code for user");

        await emailSender.SendCodeAsync(user.Login, code, CodeReason.ConfirmEmail);

        return BaseResponse(StatusCodes.Status200OK, code);
    }

    [HttpPost(ServiceRoutes.Profile.VerifyEmail)]
    public async Task<IActionResult> VerifyEmailByCode([FromBody] string code)
    {
        var user = await securityService.GetCurrentUserAsync();

        if (user == null)
            return BaseResponse(StatusCodes.Status401Unauthorized, null, "User is not logged in");

        if (user.IsEmailVerified)
            return BaseResponse(StatusCodes.Status400BadRequest, null, "Email is already verified");

        var result = await codeService.ValidateTwoFactorCodeAsync(user.Id, code, CodeReason.ConfirmEmail);

        if (result == CodeValidationResult.Success)
            await userService.UpdateEmailVerificationAsync(user.Id, true);
        
        return result switch
        {
            CodeValidationResult.Success => BaseResponse(StatusCodes.Status200OK, null, "Code is verified"),
            CodeValidationResult.Expired => BaseResponse(StatusCodes.Status400BadRequest, null, "Email is expired"),
            CodeValidationResult.InvalidCode => BaseResponse(StatusCodes.Status400BadRequest, null, "Invalid code"),
            _ => BaseResponse(StatusCodes.Status400BadRequest, null, "Invalid code")
        };
    }
}