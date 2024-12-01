﻿using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace LongDistanceService.Domain.Services.Options;

public record JwtOptions(
    string Issuer,
    string Audience,
    string SigningKey,
    int ExpirationSeconds,
    int RefreshExpirationSeconds,
    string TokenAlgorithm,
    string RefreshTokenAlgorithm)
{
    public TimeSpan ClockSkew { get; set; } = TimeSpan.FromMinutes(5);
    public SymmetricSecurityKey SymmetricSecurityKey =>
        new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SigningKey));
}