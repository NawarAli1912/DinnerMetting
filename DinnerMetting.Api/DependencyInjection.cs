using DinnerMetting.Api.Common.Errors;
using DinnerMetting.Api.Common.Mapping;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace DinnerMetting.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddApi(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddSingleton<ProblemDetailsFactory, DinnerMettingProblemDetailsFactory>();
        services.AddMapping();

        return services;
    }
}
