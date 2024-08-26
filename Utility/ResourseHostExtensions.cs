using System;
using Avalonia.Controls;
using Microsoft.Extensions.DependencyInjection;

namespace inventory_control.front;

public static class ResourseHostExtensions
{

    public static IServiceProvider GetServiceProvider(this IResourceHost control)
    {
        return (IServiceProvider)(control.FindResource(typeof(IServiceProvider)) ??
                                  throw new ApplicationException("Service provider is not present"));
    }

    public static T CreateInstance<T>(this IResourceHost control)
    {
        return ActivatorUtilities.CreateInstance<T>(control.GetServiceProvider());
    }
}