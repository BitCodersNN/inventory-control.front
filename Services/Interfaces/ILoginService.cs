using System;
using System.ComponentModel;
using System.Threading.Tasks;
using inventory_control.front.Models;
using LanguageExt.Common;

namespace inventory_control.front.Services.Interfaces;

public interface ILoginService : IApplicationService
{
    bool IsLoggedIn { get; }
    /// <summary>
    /// User data stored after last successful login
    /// </summary>
    User? CurrentUser { get; }
    /// <summary>
    /// Makes an attempt to log in using login and password. Stores current user data in <see cref="CurrentUser" />
    /// and changes <see cref="IsLoggedIn" /> to <c>true</c> if login succeeds
    /// </summary>
    /// <returns>bool result: <br />
    ///  - <c>true</c> if login succeeded <br />
    ///  - <c>false</c> if incorrect credentials were given <br />
    ///  - <c>IsSuccess = false</c> if any other error happened
    /// </returns>
    Task<Result<bool>> LoginAsync(string login, string password);

    void Logout();
}