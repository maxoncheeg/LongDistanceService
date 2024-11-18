using LongDistanceService.Domain.Models.Abstract;
using LongDistanceService.Domain.Services;
using LongDistanceService.Domain.Services.Abstract;
using LongDistanceService.Domain.Services.Options;
using LongDistanceService.Domain.Tests.Mocks;
using Microsoft.IdentityModel.Tokens;

namespace LongDistanceService.Domain.Tests.Services;

[TestFixture]
public class AccessTokenServiceTests
{
    private IAccessTokenService _tokenService = null!;
    private IUser _user = null!;

    [SetUp]
    public void SetUp()
    {
        var options = new JwtOptions(
            "localhost",
            "localhost",
            "tj2ogj408gj4230gj028gj2084gj2408g24",
            1,
            5,
            SecurityAlgorithms.HmacSha256Signature,
            SecurityAlgorithms.Aes128CbcHmacSha256)
        {
            ClockSkew = TimeSpan.Zero
        };

        _tokenService = new AccessTokenService(options);

        _user = new MockUser() { Id = 1, Login = "one" };
    }

    [Test]
    public async Task GenerateAndVerifyTokenTest()
    {
        var token = _tokenService.GenerateToken(_user).AccessToken;

        Assert.IsTrue(await _tokenService.ValidateTokenAsync(token));
    }

    [Test]
    public async Task GenerateAndVerifyRefreshTokenTest()
    {
        var token = _tokenService.GenerateRefreshToken(_user);

        Assert.IsTrue(await _tokenService.ValidateTokenAsync(token));
    }

    [Test]
    public async Task GenerateAndVerifyTokenTest_Expired()
    {
        var token = _tokenService.GenerateToken(_user).AccessToken;
        await Task.Delay(2000);
        Assert.IsFalse(await _tokenService.ValidateTokenAsync(token));
    }

    [TestCase(2000, true)]
    [TestCase(6000, false)]
    public async Task RefreshTokenTest(int milliseconds, bool result)
    {
        var token = _tokenService.GenerateToken(_user).AccessToken;
        var refreshToken = _tokenService.GenerateRefreshToken(_user);

        await Task.Delay(milliseconds); // token is expired

        var newToken = await _tokenService.RefreshTokenAsync(refreshToken, token);

        Assert.IsTrue((newToken != null) == result);
    }
}