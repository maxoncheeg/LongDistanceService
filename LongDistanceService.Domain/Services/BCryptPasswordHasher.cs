using LongDistanceService.Domain.Services.Abstract;
using BCryptHasher = BCrypt.Net.BCrypt;

namespace LongDistanceService.Domain.Services;

public class BCryptPasswordHasher : IPasswordHasher
{
    public string Hash(string password)
    {
        return BCryptHasher.HashPassword(password);
    }

    public bool VerifyHashedPassword(string hashedPassword, string password)
    {
        return BCryptHasher.Verify(password, hashedPassword);
    }
}