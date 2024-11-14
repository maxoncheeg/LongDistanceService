using System.Security.Claims;

namespace LongDistanceService.Domain.Models.Abstract;

public interface ITokenData
{
    public string AccessToken { get; }
    public IList<Claim> Claims { get; }
}