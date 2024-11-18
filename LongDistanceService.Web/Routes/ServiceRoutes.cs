namespace LongDistanceService.Web.Routes;

public static class ServiceRoutes
{
    public const string Home = "";
    
    public static class Identity
    {
        private const string IdentityRoute = "identity";
        
        public const string Login = IdentityRoute + "/login";
        public const string Register = IdentityRoute + "/register";
        
        public const string LoginType = Login + "/{type}";
        public const string AdminLogin = Login + "/admin";
        public const string UserLogin = Login + "/user";

        public const string RefreshToken = Login + "/refresh";
    }

    public static class Codes
    {
        public const string NotFound = "notfound";
    }
}