using System;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using inventory_control.front.Models;
using inventory_control.front.Services.Interfaces;
using LanguageExt.Common;

namespace inventory_control.front.Services;

public class LoginService : ObservableObject, ILoginService
{
    private bool _isLoggedIn;

    public bool IsLoggedIn
    {
        get => _isLoggedIn;
        private set => SetProperty(ref _isLoggedIn, value);
    }

    public User? CurrentUser { get; private set; }

    public async Task<Result<bool>> LoginAsync(string login, string password)
    {
        await Task.Delay(2000);
        CurrentUser = new User("Admin", UserPermissions.Full, "", "");
        IsLoggedIn = true;
        return true;
    }
}