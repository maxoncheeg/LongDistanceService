﻿namespace LongDistanceService.Web.Routes;

public static class ServiceRoutes
{
    public const string Home = "";
    
    public static class Identity
    {
        public const string IdentityRoute = "auth";
        
        public const string Login = IdentityRoute + "/login";
        public const string Register = IdentityRoute + "/register";
        
        public const string LoginType = Login + "/{type}";
        public const string AdminLogin = Login + "/user";
        public const string UserLogin = Login + "/user";
        
        public const string ChangePassword = IdentityRoute + "/change_password";
        public const string User = IdentityRoute + "/user";
        public const string UserCreate = User + "/create";
        public const string UserEdit = User + "/edit";

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
        public const string Bank = ReferenceRoute + "/banks";
        public const string VehicleBrands = ReferenceRoute + "/vehicle_brands";
        public const string VehicleModels = ReferenceRoute + "/vehicle_models";
        public const string Unit = ReferenceRoute + "/units";
        public const string CargoCategory = ReferenceRoute + "/cargo_categories";
        public const string Cargo = ReferenceRoute + "/cargoes";
        public const string DriverCategory = ReferenceRoute + "/driver_categories";
        public const string Street = ReferenceRoute + "/streets";
        public const string City = ReferenceRoute + "/cities";
    }
    
    public static class Application
    {
        public const string Route = "application";

        public const string List = Route + "/list";
        public const string Chat = Route + "/{id}";
        public const string Create = Route + "/create";
    }
    
    public static class Clients
    {
        public const string Route = "clients";

        public const string Legal = Route + "/legals";
        public const string Individual = Route + "/individuals";
    }
    
    public static class Admin
    {
        public const string Route = "admin";

        public const string Excel = Route + "/excel";
        public const string Word = Route + "/word";
    }
    
    public static class Vehicles
    {
        public const string Route = "vehicle";
        
        public const string Edit = Route + "/edit";
        public const string TypedEdit = Edit + "/{id}/{type}";
    }

    public static class Orders
    {
        public const string Route = "orders";
        public const string Show = Route + "/{id}/show";
        public const string Add = Route + "/add";
    }

    public static class Drivers
    {
        public const string Route = "driver";
    }

    public static class Hubs
    {
        public const string ApplicationChat = "application_chat";
    }
}