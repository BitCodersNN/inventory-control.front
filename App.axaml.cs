using System;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using inventory_control.front.ViewModels;
using inventory_control.front.Views;
using LanguageExt;
using Microsoft.Extensions.DependencyInjection;

namespace inventory_control.front;

public partial class App : Application
{
    public static IServiceProvider Services;
    public override void Initialize()
    {
        
        AvaloniaXamlLoader.Load(this);
        // initialize dependency injection
        var collection = new ServiceCollection();
        collection.AddApplicationServices();
        Services = collection.BuildServiceProvider();
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            // Line below is needed to remove Avalonia data validation.
            // Without this line you will get duplicate validations from both Avalonia and CT
            BindingPlugins.DataValidators.RemoveAt(0);
            desktop.MainWindow = new MainWindowView
            {
                DataContext = Services.GetRequiredService<MainWindowViewModel>(),
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}