using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.DependencyInjection;

namespace inventory_control.front.ViewModels;

public class ViewModelBase : ObservableObject
{
    protected static T GetService<T>() where T : notnull => App.Services.GetRequiredService<T>();
}
