﻿using DeToiServer.Services.AccountService;
using DeToiServer.Services.AddressService;
using DeToiServer.Services.AdminService;
using DeToiServer.Services.ChattingService;
using DeToiServer.Services.CustomerAccountService;
using DeToiServer.Services.FavoriteService;
using DeToiServer.Services.FreelanceAccountService;
using DeToiServer.Services.FreelanceQuizService;
using DeToiServer.Services.FreelanceSkillService;
using DeToiServer.Services.MessageQueueService;
using DeToiServer.Services.NotificationService;
using DeToiServer.Services.OrderManagementService;
using DeToiServer.Services.PaymentService;
using DeToiServer.Services.ReportService;
using DeToiServer.Services.ServiceCategoryService;
using DeToiServer.Services.ServiceProvenService;
using DeToiServer.Services.ServiceStatusService;
using DeToiServer.Services.ServiceTypeService;
using DeToiServer.Services.UIElementService;
using DeToiServer.Services.UserService;
using DeToiServerCore.Common.Constants;
using DeToiServerCore.CustomAttribute;
using DeToiServerData.Repositories;
using DeToiServerData.Repositories.AccountCustomerRepo;
using DeToiServerData.Repositories.AccountFreelanceRepo;
using DeToiServerData.Repositories.AddressRepo;
using DeToiServerData.Repositories.AdminRepo;
using DeToiServerData.Repositories.FreelanceQuizRepo;
using DeToiServerData.Repositories.FreelancerQuizRepo;
using DeToiServerData.Repositories.FreelanceSkillRepo;
using DeToiServerData.Repositories.MessageRepo;
using DeToiServerData.Repositories.OrderRepo;
using DeToiServerData.Repositories.PaymentRepo;
using DeToiServerData.Repositories.PromotionRepo;
using DeToiServerData.Repositories.ReportRepo;
using DeToiServerData.Repositories.ServiceCategoryRepo;
using DeToiServerData.Repositories.ServiceRepo;
using DeToiServerData.Repositories.ServiceStatusRepo;
using DeToiServerData.Repositories.ServiceTypeRepo;
using DeToiServerData.Repositories.UIElementServiceRequirementRepo;
using DeToiServerData.Repositories.UserRepo;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using Swashbuckle.AspNetCore.Filters;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Text;
using System.Threading.RateLimiting;

namespace DeToiServerData
{
    public class SecurityRequirementsOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var hasAuthorize = context.MethodInfo.DeclaringType!.GetCustomAttributes(true).OfType<AuthorizeRolesAttribute>().Any() ||
                               context.MethodInfo.GetCustomAttributes(true).OfType<AuthorizeRolesAttribute>().Any();

            if (hasAuthorize)
            {
                if (operation.Security == null)
                    operation.Security = new List<OpenApiSecurityRequirement>();

                var oauth2Scheme = new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "oauth2"
                    }
                };

                operation.Security.Add(new OpenApiSecurityRequirement
                {
                    [oauth2Scheme] = new[] { "readAccess", "writeAccess" }
                });
            }
        }
    }

    public static class Extension
    {
        public static void AddCustomSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Description = "Standard Authorization header using the Bearer scheme (\"bearer {token}\")",
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });

                options.OperationFilter<SecurityRequirementsOperationFilter>();
            });
        }

        public static void AddJwtBearerAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
                            .GetBytes(configuration.GetSection("AppSettings:Token").Value!)),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });
        }

        public static IServiceCollection AddUnitOfWork(this IServiceCollection services, Action<DbContextOptionsBuilder> optionsAction)
        {
            services.AddDbContext<DataContext>(optionsAction);
            services.AddScoped<IAccountRepo, AccountRepo>();
            services.AddScoped<ICustomerAccountRepo, CustomerAccountRepo>();
            services.AddScoped<IFreelanceAccountRepo, FreelanceAccountRepo>();
            services.AddScoped<IServiceTypeRepo, ServiceTypeRepo>();
            services.AddScoped<IServiceStatusRepo, ServiceStatusRepo>();
            services.AddScoped<IServiceCategoryRepo, ServiceCategoryRepo>();
            services.AddScoped<IServiceProvenRepo, ServiceProvenRepo>();
            services.AddScoped<IPromotionRepo, PromotionRepo>();
            services.AddScoped<IBiddingOrderRepo, BiddingOrderRepo>();
            services.AddScoped<IOrderRepo, OrderRepo>();
            services.AddScoped<IServiceRepo, ServiceRepo>();
            services.AddScoped<IUserRepo, UserRepo>();
            services.AddScoped<IFavoriteRepo, FavoriteRepo>();

            services.AddScoped<IUIElementServiceRequirementRepo, UIElementServiceRequirementRepo>();
            services.AddScoped<IUIElementAdditionServiceRequirementRepo, UIElementAdditionServiceRequirementRepo>();

            services.AddScoped<IFreelanceQuizRepo, FreelanceQuizRepo>();
            services.AddScoped<IFreelanceSkillRepo, FreelanceSkillRepo>();

            services.AddScoped<IAddressRepo, AddressRepo>();
            services.AddScoped<IPaymentRepo, PaymentRepo>();
            services.AddScoped<IReportRepo, ReportRepo>();
            services.AddScoped<IAdminRepo, AdminRepo>();
            services.AddScoped<IMessageRepo, MessageRepo>();


            services.AddScoped<UnitOfWork>();
            return services;
        }

        public static IServiceCollection AddServicesData(this IServiceCollection services)
        {
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IFreelanceAccountService, FreelanceAccountService>();
            services.AddScoped<ICustomerAccountService, CustomerAccountService>();
            services.AddScoped<IServiceTypeService, ServiceTypeService>();
            services.AddScoped<IServiceStatusService, ServiceStatusService>();
            services.AddScoped<IServiceCategoryService, ServiceCategoryService>();
            services.AddScoped<IServiceProvenService, ServiceProvenService>();
            services.AddScoped<IOrderManagementService, OrderManagementService>();
            services.AddScoped<IBiddingOrderService, BiddingOrderService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IMessageQueueService, MessageQueueService>();
            services.AddScoped<IFavoriteService, FavoriteService>();
            services.AddScoped<IUIElementServiceRequirementService, UIElementServiceRequirementService>();
            services.AddScoped<IFreelanceQuizService, FreelanceQuizService>();
            services.AddScoped<IFreelanceSkillService, FreelanceSkillService>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IAddressService, AddressService>();
            services.AddSingleton<INotificationService, NotificationService>();
            services.AddScoped<IAdminService, AdminService>();
            services.AddScoped<INotificationDataService, NotificationDataService>();
            services.AddScoped<IReportService, ReportService>();
            services.AddScoped<IChattingService, ChattingService>();
            return services;
        }

        public static IServiceCollection AddCustomRateLimiter(this IServiceCollection services)
        {
            services.AddRateLimiter(options =>
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
                            PermitLimit = GlobalConstant.OTP.PermitCount,
                            Window = TimeSpan.FromSeconds(10), // TODO: Need fix
                            QueueLimit = 0
                        }));
            });

            return services;
        } 

        public static void ApplyDatabaseMigrations(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetRequiredService<DataContext>();
                var logger = serviceScope.ServiceProvider.GetRequiredService<ILogger<IApplicationBuilder>>();

                try
                {
                    var databaseCreator = dbContext.Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
                    if (dbContext.Database.GetPendingMigrations().Any() || !databaseCreator!.CanConnect() || !databaseCreator!.HasTables())
                    {
                        var filePath = Path.Combine(env.ContentRootPath, GlobalConstant.SqlFiles.DataFile);
                        var sqlJobPath = Path.Combine(env.ContentRootPath, GlobalConstant.SqlFiles.SqlJobs);

                        logger.LogInformation("Applying migrations and execute example data");
                        dbContext.Database.Migrate();
                        ExecuteSqlFromFile(dbContext, filePath);
                        ExecuteSqlFromFile(dbContext, sqlJobPath);
                    }
                }
                catch (Exception ex)
                {
                    logger.LogError(ex.Message, ex.StackTrace);
                }
            }
        }

        public static void AddLoggingScheme(this IHostApplicationBuilder builder)
        {
            if (builder.Environment.IsDevelopment())
            {
                builder.Services.AddLogging();
            }
            else
            {
                var logger = new LoggerConfiguration()
                    .ReadFrom.Configuration(builder.Configuration)
                    .Enrich.FromLogContext()
                    .CreateLogger();
                            builder.Logging.ClearProviders();
                            builder.Logging.AddSerilog(logger);
            }
        }

        private static void ExecuteSqlFromFile(DataContext dbContext, string filePath)
        {
            FileInfo file = new(filePath);
            string script = file.OpenText().ReadToEnd();
            dbContext.Database.ExecuteSqlInterpolated($"Execute({script});");
        }
    }
}
