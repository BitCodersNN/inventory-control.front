using System;
using System.Collections.Generic;
using System.Linq;
using inventory_control.front.Models;
using Microsoft.Extensions.DependencyInjection;

namespace inventory_control.front.ViewModels.Pages.MainPage.Utility;

public class PagesListFactory
{
    private static readonly Dictionary<Type, UserPermissions> PermittedPages =
        new Dictionary<Type, UserPermissions>()
        {
            { typeof(DataEntryPageViewModel), UserPermissions.Write },
            { typeof(PrintingPage), UserPermissions.Read },
            { typeof(OrdersPage), UserPermissions.Read },
            { typeof(WarehousePage), UserPermissions.Read },
            { typeof(AnalyticsPage), UserPermissions.Read },
            {typeof(AccountsPage), UserPermissions.Manage},
            {typeof(HistoryPage), UserPermissions.Read},
        };

    public static List<ViewModelBase> GetPagesForUser(User user)
    {
        List<ViewModelBase> pages = PermittedPages.Where(p => user.Permissions.HasFlag(p.Value))
            .Map(p => (ViewModelBase) App.Services.GetRequiredService(p.Key)).ToList();
        return pages;
    }
}