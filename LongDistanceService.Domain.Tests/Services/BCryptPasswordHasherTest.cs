﻿using LongDistanceService.Domain.Services;
using LongDistanceService.Domain.Services.Utils;
using LongDistanceService.Domain.Services.Utils.Abstract;

namespace LongDistanceService.Domain.Tests.Services;

[TestFixture]
public class BCryptPasswordHasherTest
{
    private IPasswordHasher _passwordHasher = null!;
    
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
        Console.WriteLine(hash);
        Assert.IsTrue(_passwordHasher.VerifyHashedPassword(hash, password));
    }
}