using LongDistanceService.Domain.Services.Utils.Abstract;
using BCryptHasher = BCrypt.Net.BCrypt;

namespace LongDistanceService.Domain.Services.Utils;

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