using inventory_control.front.Services;
using inventory_control.front.Services.Interfaces;
using inventory_control.front.ViewModels;
using inventory_control.front.ViewModels.Pages;
using inventory_control.front.ViewModels.Pages.MainPage;
using Microsoft.Extensions.DependencyInjection;

namespace inventory_control.front;

public static class ServiceCollectionExtensions
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddSingleton<ILoginService, LoginService>();
        services.AddTransient<MainWindowViewModel>();
        services.AddTransient<LoginPageViewModel>();
        services.AddTransient<MainPageViewModel>();
        services.AddTransient<DataEntryPageViewModel>();

    }
}