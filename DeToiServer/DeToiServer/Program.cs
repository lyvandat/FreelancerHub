global using DeToiServerCore.Models;
global using DeToiServerData;
using DeToiServer;
using DeToiServer.AutoMapper;
using DeToiServer.ConfigModels;
using DeToiServer.Middlewares;
using DeToiServer.RealTime;
using DeToiServer.Services.CacheService;
using DeToiServer.WorkerServices;
using DeToiServerCore.Common.Helper;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

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
    options.UseSqlServer(builder.Configuration.GetConnectionString("local_dat"))); 
// builder.Configuration.GetConnectionString("local")
// Helper.GetDockerConnectionString()

builder.Services.AddHttpContextAccessor();
builder.Services.AddSignalR();
builder.Services.AddSingleton<RealtimeConsumer>();
builder.Services.AddScoped<ICacheService, CacheService>();
// Message queue to communicate between services (in microservice architecture)
//builder.Services.AddSingleton<IMessageBusClient, MessageBusClient>();
//builder.Services.AddSingleton<IEventProcessor, EventProcessor>();
//builder.Services.AddHostedService<MessageBusSubscriber>();
builder.Services.Configure<VnPayConfigModel>(builder.Configuration.GetSection("VnPayConfig"));
builder.Services.AddHostedService<NotificationDataCleanupService>();
builder.Services.AddCustomRateLimiter();
builder.Services.AddHttpClient();
var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseCors("NgOrigins");
app.ApplyDatabaseMigrations(app.Environment);
app.UseMiddleware<GlobalExceptionHandlerMiddleware>();
app.UseMiddleware<DeviceAuthenticationMiddleware>();

app.UseRateLimiter();

// Add other configurations
app.MapHub<ChatHub>("chat-hub");
app.UseAuthorization();
app.MapControllers();

app.Run();
