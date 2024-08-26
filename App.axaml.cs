using System;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using inventory_control.front.ViewModels;
using inventory_control.front.Views;
using Microsoft.Extensions.DependencyInjection;

namespace inventory_control.front;

public partial class App : Application
{
    public override void Initialize()
    {
        
        AvaloniaXamlLoader.Load(this);
        // initialize dependency injection
        var collection = new ServiceCollection();
        collection.AddApplicationServices();
        IServiceProvider services = collection.BuildServiceProvider();
        Resources[typeof(IServiceProvider)] = services;
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            // Line below is needed to remove Avalonia data validation.
            // Without this line you will get duplicate validations from both Avalonia and CT
            BindingPlugins.DataValidators.RemoveAt(0);
            desktop.MainWindow = new MainWindow
            {
                DataContext = this.CreateInstance<MainWindowViewModel>(),
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}