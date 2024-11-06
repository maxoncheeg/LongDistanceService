namespace LongDistanceService.Web.Routes;

public static class ServiceRoutes
{
    public const string Identity = "identity";

    public const string Login = Identity + "/login";
    public const string LoginType = Login + "/{type}";
    public const string AdminLogin = Login + "/admin";
    public const string UserLogin = Login + "/user";

    public const string Register = Identity + "register";
}