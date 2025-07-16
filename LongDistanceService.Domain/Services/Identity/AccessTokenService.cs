using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using LongDistanceService.Domain.Enums;
using LongDistanceService.Domain.Models;
using LongDistanceService.Domain.Models.Abstract;
using LongDistanceService.Domain.Models.Abstract.Users;
using LongDistanceService.Domain.Services.Identity.Abstract;
using LongDistanceService.Domain.Services.Options;
using Microsoft.IdentityModel.Tokens;

namespace LongDistanceService.Domain.Services.Identity;

public class AccessTokenService(JwtOptions jwtOptions)
    : IAccessTokenService
{
    private readonly JwtSecurityTokenHandler _tokenHandler = new();

    public ITokenData GenerateToken(IUser user)
    {
        var expiration = TimeSpan.FromSeconds(jwtOptions.ExpirationSeconds);
        var claims = ConfigureClaims(user);
        var token = GenerateToken(jwtOptions.TokenAlgorithm, expiration, claims);

        return new TokenData(token, claims);
    }

    public string GenerateRefreshToken(IUser user)
    {
        var expiration = TimeSpan.FromSeconds(jwtOptions.RefreshExpirationSeconds);
        var claims = ConfigureClaims(user);
        var token = GenerateToken(jwtOptions.RefreshTokenAlgorithm, expiration, claims);

        return token;
    }

    public async Task<string?> RefreshTokenAsync(string refreshToken, string expiredToken)
    {
        var refreshResult = await GetValidationResultAsync(refreshToken);
        var expiredResult = _tokenHandler.ReadJwtToken(expiredToken);

        if (refreshResult.IsValid && expiredResult != null)
        {
            var expiration = TimeSpan.FromSeconds(jwtOptions.ExpirationSeconds);

            if (!refreshResult.Claims.TryGetValue(Claims.Identifier, out var id))
                return null;
            if (!refreshResult.Claims.TryGetValue(Claims.Email, out var name))
                return null;

            // todo: maybe to much for statements
            string? normalId = id.ToString(),
                normalName = name.ToString(),
                expiredNormalName = expiredResult.Claims.FirstOrDefault(c => c.Type == Claims.Email)?.Value
                    .ToString(),
                expiredNormalId = expiredResult.Claims.FirstOrDefault(c => c.Type == Claims.Identifier)?.Value
                    .ToString();

            if (normalId == null || normalName == null) return null;
            if (expiredNormalName == null || expiredNormalId == null) return null;

            if (normalId != expiredNormalId || normalName != expiredNormalName) return null;

            return GenerateToken(jwtOptions.TokenAlgorithm, expiration, expiredResult.Claims);
        }

        return null;
    }

    public async Task<bool> ValidateTokenAsync(string token)
    {
        var result = await GetValidationResultAsync(token);

        return result.IsValid;
    }

    public async Task<ILoginUser?> GetUserDataFromTokenAsync(string token)
    {
        var result = await GetValidationResultAsync(token);

        if (!result.IsValid)
            return null;

        if (!result.Claims.TryGetValue(Claims.Identifier, out var claimId)
            || !int.TryParse(claimId.ToString(), out var id))
            return null;

        if (!result.Claims.TryGetValue(Claims.Email, out var name))
            return null;

        string? login = name.ToString();

        if (login != null)
            return new LoginUser(id) { Login = login };
        return null;
    }

    private async Task<TokenValidationResult> GetValidationResultAsync(string token)
    {
        var result = await _tokenHandler.ValidateTokenAsync(token, GetParameters());

        return result;
    }

    private string GenerateToken(string algorithm, TimeSpan expiration, IEnumerable<Claim> claims)
    {
        var token = new JwtSecurityToken(
            issuer: jwtOptions.Issuer,
            audience: jwtOptions.Audience,
            claims: claims,
            expires: DateTime.UtcNow.Add(expiration),
            signingCredentials: new SigningCredentials(jwtOptions.SymmetricSecurityKey, algorithm));

        var rawToken = _tokenHandler.WriteToken(token);

        return rawToken;
    }

    private IList<Claim> ConfigureClaims(IUser user)
    {
        var claims = new List<Claim>
        {
            new(Claims.Identifier, user.Id.ToString()),
            new(Claims.Email, user.Login),
            new(Claims.EmailVerified, user.IsEmailVerified.ToString()),
            new(Claims.ExternalUser, user.IsExternalUser.ToString())
        };
        
        claims.AddRange(user.Roles.Select(role => new Claim(Claims.Role, role.Type.ToString())));

        return claims;
    }

    private TokenValidationParameters GetParameters()
    {
        return new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            RequireExpirationTime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtOptions.Issuer,
            ValidAudience = jwtOptions.Audience,
            ClockSkew = jwtOptions.ClockSkew,
            IssuerSigningKey = jwtOptions.SymmetricSecurityKey
        };
    }
}