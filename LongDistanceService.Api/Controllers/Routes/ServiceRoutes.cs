namespace LongDistanceService.Api.Controllers.Routes;

public static class ServiceRoutes
{
    public const string Base = "api/";
    public const string Test = Base + "test/";

    public static class TestRoutes
    {
        public const string GetRandomNumber = Test + "randomnum";
        public const string GetAgeByYear = Test + "age/{year}";
        public const string GetTestTrucks = Test + "trucks";
        public const string CreateTestTruck = Test + "trucks";
    }
}