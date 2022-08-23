using Microsoft.Extensions.DependencyInjection;

namespace App.Core.StudentModule;

public static class ServiceConfiguration
{
    public static IServiceCollection AddStudentModuleService(this IServiceCollection services)
    {
        // If naay ato gusto na i-inject o i-add na service para sa StudentModule o sa ngadi
        // da na foler ngadi nato i-butang ang ato mga services
        // or dependencies
        return services;
    }
}