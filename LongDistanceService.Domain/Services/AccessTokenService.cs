using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using LongDistanceService.Domain.Models;
using LongDistanceService.Domain.Models.Abstract;
using LongDistanceService.Domain.Services.Abstract;
using LongDistanceService.Domain.Services.Options;
using Microsoft.IdentityModel.Tokens;

namespace LongDistanceService.Domain.Services;

public class AccessTokenService(JwtOptions jwtOptions, TokenValidationParameters validationParameters) : IAccessTokenService
{
    private readonly JwtSecurityTokenHandler _tokenHandler = new();

    public ITokenData GenerateToken(IUser user)
    {
        var expiration = TimeSpan.FromMinutes(60);

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.Login),
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
        };

        var token = new JwtSecurityToken(
            issuer: jwtOptions.Issuer,
            audience: jwtOptions.Audience,
            claims: claims,
            expires: DateTime.Now.Add(expiration),
            signingCredentials: new SigningCredentials(jwtOptions.SymmetricSecurityKey,
                SecurityAlgorithms.HmacSha256Signature));

        var rawToken = _tokenHandler.WriteToken(token);
        
        return new TokenData(rawToken, claims);
    }

    public async Task<IUser?> ValidateTokenAsync(string token)
    {
        var result = await _tokenHandler.ValidateTokenAsync(token, validationParameters);

        if (!result.Claims.TryGetValue(ClaimTypes.NameIdentifier, out var claimId)
            || !int.TryParse(claimId.ToString(), out var id))
            return null;

        if (!result.Claims.TryGetValue(ClaimTypes.Name, out var name))
            return null;

        string? login = name.ToString();

        if (login != null)
            return new User() { Id = id, Login = login };
        return null;
    }
}