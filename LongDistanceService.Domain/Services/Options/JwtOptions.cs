using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace LongDistanceService.Domain.Services.Options;

public record JwtOptions(
    string Issuer,
    string Audience,
    string SigningKey,
    int ExpirationSeconds)
{
    public SymmetricSecurityKey SymmetricSecurityKey =>
        new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SigningKey));
}