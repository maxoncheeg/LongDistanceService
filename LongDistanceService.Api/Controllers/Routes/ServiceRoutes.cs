namespace LongDistanceService.Api.Controllers.Routes;

public static class ServiceRoutes
{
    public const string Api = "api/";

    public static class Test
    {
        public const string Base = Api + "test/";
        public const string GetRandomNumber = Base + "randomnum/";
        public const string GetAgeByYear = Base + "age/{year}/";
        public const string GetTestTrucks = Base + "trucks/";
        public const string CreateTestTruck = Base + "trucks/";
    }

    public static class Auth
    {
        public const string Base = Api + "auth/";
        public const string Login = Base + "login/";
    }
}