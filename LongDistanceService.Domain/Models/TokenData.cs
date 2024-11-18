using System.Security.Claims;
using LongDistanceService.Domain.Models.Abstract;

namespace LongDistanceService.Domain.Models;

public record TokenData(string AccessToken, IList<Claim> Claims) : ITokenData;