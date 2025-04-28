using System.Diagnostics.Metrics;
using System.Reflection;
using LongDistanceService.Api.Middlewares;
using LongDistanceService.Domain.Services;
using LongDistanceService.Domain.Services.Abstract;
using LongDistanceService.Shared.DependencyInjection.Data;
using LongDistanceService.Shared.DependencyInjection.MediatR;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

const string serviceName = "long_distance_service";

#region OpenTelemetry

builder.Services.AddOpenTelemetry()
    .ConfigureResource(resource => resource.AddService(serviceName))
    .WithTracing(tracing => tracing
        .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService("LongDistanceService.Api"))
        .AddSource("TestController")
        .AddAspNetCoreInstrumentation()
        .AddHttpClientInstrumentation()
        .AddEntityFrameworkCoreInstrumentation()
        .AddSqlClientInstrumentation()
        .AddOtlpExporter(options =>
        {
            options.Endpoint = new Uri("http://localhost:4317"); // Endpoint для OTLP
            options.TimeoutMilliseconds = 5000;
        })
    )
    .WithMetrics(metrics => metrics
        .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService("LongDistanceService.Api"))
        .AddAspNetCoreInstrumentation()
        .AddRuntimeInstrumentation()
        .AddHttpClientInstrumentation()
        .AddMeter("ControllerMeter")
        .AddPrometheusExporter()
    );

#endregion

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
                       throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddPostgresDatabase(connectionString).AddPostresConnection(connectionString);
builder.Services.AddScoped<IVehicleService, VehicleService>();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()))
    .AddMediatRHandlers();

var app = builder.Build();

app.UseMiddleware<ExceptionHandlerMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var meter = new Meter("lds_metrics");

var requestBodySizeCounter = meter.CreateCounter<long>(
    "request_body_size",
    unit: "bytes",
    description: "Size of incoming HTTP request bodies in bytes"
);

app.UseOpenTelemetryPrometheusScrapingEndpoint();
app.Use((context, next) =>
{
    if (context.Request.ContentLength.HasValue || context.Response.ContentLength.HasValue)
    {
        var bytes = context.Request.ContentLength ?? 0 + context.Response.ContentLength ?? 0;
        requestBodySizeCounter.Add(bytes,
            new KeyValuePair<string, object?>("route", context.Request.Method + " " + context.Request.Path));
    }

    return next(context);
});

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseCookiePolicy();

app.UseAuthentication();
app.UseAuthorization();


app.UseCors(options =>
{
    options.WithOrigins("http://localhost:5173");
    options.AllowAnyMethod();
    options.AllowAnyHeader();
});

app.UseEndpoints(endpoints => { endpoints.MapControllers(); });


app.Urls.Add("http://localhost:80");
app.Run();