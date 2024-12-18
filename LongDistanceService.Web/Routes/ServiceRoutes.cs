﻿namespace LongDistanceService.Web.Routes;

public static class ServiceRoutes
{
    public const string Home = "";
    
    public static class Identity
    {
        public const string IdentityRoute = "identity";
        
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
    
    public static class Reference
    {
        public const string ReferenceRoute = "reference";

        public const string Blank = ReferenceRoute + "/blank/{type}";
        public const string Generic = ReferenceRoute + "/{type}";
        
        public const string Sql = ReferenceRoute + "/sql";
    }
    
    public static class Application
    {
        public const string Route = "application";

        public const string List = Route + "/list";
        public const string Chat = Route + "/{id}";
        public const string Create = Route + "/create";
    }
    
    public static class Admin
    {
        public const string Route = "admin";

        public const string Excel = Route + "/excel";
        public const string Word = Route + "/word";
    }
}