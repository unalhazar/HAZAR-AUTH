using Application.Abstraction;
using Application.Contracts.Persistence;
using Infrastructure.AppServices.LogService.User;
using Infrastructure.AppServices.TokenBlacklistService;
using Infrastructure.Persistence;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;


namespace Infrastructure.DependencyInjection
{
    public static class ServiceContainer
    {
        public static IServiceCollection InfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<HazarAuthDbContext>(
                options => options.UseNpgsql(configuration.GetConnectionString("Default"),
                b => b.MigrationsAssembly(typeof(ServiceContainer).Assembly.FullName)),
                ServiceLifetime.Scoped);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme; ;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidAudience = configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!))
                };
            });


            // Logging service'i ekleyin
            services.AddScoped<ILogUserService, LogUserService>();

            // Repository'i ekleyin
            services.AddScoped<IUser, UserRepository>();
            services.AddScoped<ILogUserRepository, LogUserRepository>();
            services.AddScoped<IApplicationUserRepository, ApplicationUserRepository>();
            services.AddScoped<ITokenBlacklistService, TokenBlacklistService>();
            // Diğer servis kayıtları

            return services;
        }
    }
}
