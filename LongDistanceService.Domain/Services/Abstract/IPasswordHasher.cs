namespace LongDistanceService.Domain.Services.Abstract;

public interface IPasswordHasher
{
    public string Hash(string password);
    public bool VerifyHashedPassword(string hashedPassword, string password);
}