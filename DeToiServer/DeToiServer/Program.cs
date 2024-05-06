global using DeToiServerCore.Models;
global using DeToiServerData;
using DeToiServer;
using DeToiServer.AsyncDataServices;
using DeToiServer.AutoMapper;
using DeToiServer.ConfigModels;
using DeToiServer.Middlewares;
using DeToiServer.RealTime;
using DeToiServer.WorkerServices;
using DeToiServerCore.Common.Helper;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using System.Threading.RateLimiting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.AddLoggingScheme();
builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables();
builder.Services.Configure<ApplicationSecretSettings>(builder.Configuration.GetSection("ApplicationSecrets"));

builder.Services.AddControllers()
    .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCustomSwagger();
builder.Services.AddJwtBearerAuthentication(builder.Configuration);
builder.Services.AddCors(options => options.AddPolicy(name: "NgOrigins",
    policy =>
    {
        //policy.WithOrigins("http://localhost:2014").AllowAnyMethod().AllowAnyHeader().SetIsOriginAllowed(host => true).SetIsOriginAllowedToAllowWildcardSubdomains().AllowCredentials();
        //policy.WithOrigins("http://localhost:2016").AllowAnyMethod().AllowAnyHeader().SetIsOriginAllowed(host => true).SetIsOriginAllowedToAllowWildcardSubdomains().AllowCredentials();
        //policy.WithOrigins("http://localhost:3000").AllowAnyMethod().AllowAnyHeader().SetIsOriginAllowed(host => true).SetIsOriginAllowedToAllowWildcardSubdomains().AllowCredentials();
        //policy.WithOrigins("http://localhost:8000").AllowAnyMethod().AllowAnyHeader().SetIsOriginAllowed(host => true).SetIsOriginAllowedToAllowWildcardSubdomains().AllowCredentials();
        //policy.AllowAnyHeader().AllowAnyMethod().SetIsOriginAllowed(host => true).AllowCredentials();
        policy.AllowAnyMethod().AllowAnyHeader().SetIsOriginAllowed(host => true).AllowCredentials();
    })
);

builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddServicesData();
builder.Services.AddUnitOfWork(options =>
    options.UseSqlServer(Helper.GetDockerConnectionString(), ops => ops.EnableRetryOnFailure())); // builder.Configuration.GetConnectionString("local") | Helper.GetDockerConnectionString()
builder.Services.AddHttpContextAccessor();
builder.Services.AddSignalR();
builder.Services.AddSingleton<RealtimeConsumer>();
// Message queue to communicate between services (in microservice architecture)
//builder.Services.AddSingleton<IMessageBusClient, MessageBusClient>();
//builder.Services.AddSingleton<IEventProcessor, EventProcessor>();
//builder.Services.AddHostedService<MessageBusSubscriber>();
builder.Services.Configure<VnPayConfigModel>(builder.Configuration.GetSection("VnPayConfig"));
builder.Services.AddHostedService<NotificationDataCleanupService>();

builder.Services.AddRateLimiter(options =>
{
    options.OnRejected = (context, cancellationToken) =>
    {
        _ = context.Lease.TryGetMetadata(MetadataName.RetryAfter, out var retryAfter);
        context.HttpContext.Response.StatusCode = StatusCodes.Status429TooManyRequests;
        context.HttpContext.Response.WriteAsJsonAsync(
            value: new
            {
                Message = $"Quá nhiều yêu cầu, xin hãy thử lại sau. {retryAfter}"
            },
            cancellationToken: cancellationToken);

        return new ValueTask();
    };

    options.AddPolicy("fixedWindow", httpContext =>
        RateLimitPartition.GetFixedWindowLimiter(
            partitionKey: httpContext.Connection.RemoteIpAddress?.ToString(),
            factory: _ => new FixedWindowRateLimiterOptions
            {
                PermitLimit = 5,
                Window = TimeSpan.FromSeconds(30),
                QueueLimit = 0
            }));
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseCors("NgOrigins");
app.ApplyDatabaseMigrations(app.Environment);
//app.UseMiddleware<CorsMiddleware>();
app.UseMiddleware<GlobalExceptionHandlerMiddleware>();

app.UseRateLimiter();

// Add other configurations
app.MapHub<ChatHub>("chat-hub");
app.UseAuthorization();
app.MapControllers();

app.Run();
