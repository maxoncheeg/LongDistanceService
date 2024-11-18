using LongDistanceService.Domain.Models.Abstract;
using LongDistanceService.Web.Models.Scenario.Abstract;

namespace LongDistanceService.Web.Models.Scenario;

public class AuthResult(string token, IUser user) : IAuthResult
{
    public string Token { get; set; } = token;
    public IUser User { get; set; } = user;
}