using DinnerMetting.Application.Common;
using DinnerMetting.Application.Persistence;
using DinnerMetting.Infrastructure.Authentication;
using DinnerMetting.Infrastructure.Authentication.Models;
using DinnerMetting.Infrastructure.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DinnerMetting.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {

        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

        services.AddScoped<IUserRepository, UserRepository>();
        return services;
    }
}
