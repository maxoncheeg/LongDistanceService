using LongDistanceService.Domain.Services;
using LongDistanceService.Domain.Services.Abstract;

namespace LongDistanceService.Domain.Tests.Services;

[TestFixture]
public class BCryptPasswordHasherTest
{
    private IPasswordHasher _passwordHasher;
    
    [SetUp]
    public void SetUp()
    {
        _passwordHasher = new BCryptPasswordHasher();
    }

    [TestCase("123")]
    [TestCase("maxsocool")]
    [TestCase("aMeRiK23!!?")]
    public void HashAndVerifyTest(string password)
    {
        var hash = _passwordHasher.Hash(password);
        
        Assert.IsTrue(_passwordHasher.VerifyHashedPassword(hash, password));
    }
    
}