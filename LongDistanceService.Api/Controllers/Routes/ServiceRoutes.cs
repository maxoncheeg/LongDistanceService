namespace LongDistanceService.Api.Controllers.Routes;

public static class ServiceRoutes
{
    public const string Api = "/api";

    public static class Test
    {
        public const string Base = Api + "/test";
        public const string GetRandomNumber = Base + "/randomnum";
        public const string GetAgeByYear = Base + "/age/{year}";
        public const string GetTestTrucks = Base + "/trucks";
        public const string GetTestTruckById = GetTestTrucks + "/{id}";
        public const string CreateTestTruck = Base + "/trucks";
    }

    public static class Auth
    {
        public const string Base = Api + "/auth";
        public const string Login = Base + "/login";
        public const string Register = Base + "/register";
        public const string ConfirmRegisterWithCode = Register + "/code";
        public const string ChangePassword = Base + "/password";
        public const string ConfirmPasswordWithCode = ChangePassword + "/code";
        public const string Logout = Base + "/logout";
        public const string LoginByToken = Base + "/token/login";
        public const string RefreshToken = Base + "/token/refresh";
        
        public static class OAuth
        {
            public const string Base = "/oauth";
            public const string Provider = Base + "/{provider}";
            public static string Callback(string provider) => $"{Base}/login/{provider}"; 
            public const string Authorize = Base + "/authorize";
        }
    }

    public static class Bank
    {
        public const string Base = Api + "/banks";
        public const string CreateBank = Base + "/create";
        public const string DeleteBanks = Base + "/delete";
        public const string UpdateBanks = Base + "/update";
    }
}