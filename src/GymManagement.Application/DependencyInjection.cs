namespace GymManagement.Application;

using Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<ISubsrciptionService, SubsrciptionService>();

        return services;
    }
}
