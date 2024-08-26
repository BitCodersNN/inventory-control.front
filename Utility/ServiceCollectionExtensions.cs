using inventory_control.front.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace inventory_control.front;

public static class ServiceCollectionExtensions
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddTransient<MainWindowViewModel>();
    }
}