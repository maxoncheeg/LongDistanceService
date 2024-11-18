using LongDistanceService.Domain.Models.Abstract;

namespace LongDistanceService.Web.Models.Scenario.Abstract;

public interface IAuthResult
{
    public string Token { get; set; }
    public IUser User { get; set; }
}