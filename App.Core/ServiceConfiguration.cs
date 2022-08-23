using System.Reflection;
using Mapster;
using MapsterMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace App.Core;

public static class ServiceConfiguration
{
    // If naay ato gusto na i-inject o i-add na service para sa intero App.Core  o sa ngadi
    // na ClassLibrary ngadi nato i-butang ang ato mga services or dependencies
    // Para yauy ato seperation of concern
    public static IServiceCollection AddCoreServices(this IServiceCollection services)
    {
        var typeAdapterConfig = new TypeAdapterConfig();
        
        // Hanapun nea tanan ng mga class na yaka inherit si IRegister
        // Assembly.GetExecutingAssembly kung uno na Class Library ang ginaexecute
        var mapsterScan = TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetExecutingAssembly());
        
        // I-register na nea tanan ng mga yakit.an nea na class sa TypeAdapterConfig
        mapsterScan.ToList().ForEach(register => register.Register(typeAdapterConfig));
        
        // Create ng new instance ng mapper na apil tong mga 
        // class na may IRegister interface
        // For example tong StudentTransport
        var mapsterConfig = new Mapper(typeAdapterConfig);

        // Ga require ine ng Dependency Injection Package ng MediatR
        // Dependency Injection ng MediatR
        // Same da sab sa mapper gahanap sab o ga scan ine na mga class na yaka inherit
        // si IRequest
        services.AddMediatR(Assembly.GetExecutingAssembly());
        
        // Dependency Injection ng Mapper
        services.AddSingleton<IMapper>(mapsterConfig);
        
        
        return services;
    }
}