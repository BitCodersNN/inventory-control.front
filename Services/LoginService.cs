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
    private User? _currentUser;

    public bool IsLoggedIn
    {
        get => _isLoggedIn;
        private set => SetProperty(ref _isLoggedIn, value);
    }

    public User? CurrentUser
    {
        get => _currentUser;
        private set => SetProperty(ref _currentUser, value);
    }

    public async Task<Result<bool>> LoginAsync(string login, string password)
    {
        await Task.Delay(2000);
        CurrentUser = login switch
        {
            "1" => new User("Admin", UserPermissions.Full, "", ""),
            "2" => new User("User A", UserPermissions.Read, "", ""),
            "3" => new User("User B", UserPermissions.ReadWrite, "", ""),
            _ => null
        };
        IsLoggedIn = CurrentUser != null;
        return IsLoggedIn;
    }

    public void Logout()
    {
        IsLoggedIn = false;
        CurrentUser = null;
    }
}