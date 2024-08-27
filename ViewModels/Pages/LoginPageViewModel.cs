using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using inventory_control.front.Services.Interfaces;
using LanguageExt.Common;

namespace inventory_control.front.ViewModels.Pages;

public class LoginPageViewModel : ViewModelBase
{
    private readonly ILoginService _loginService;
    public bool CanExecuteLogin => LoginCommand.CanExecute(null);
    public Task<Result<bool>>? LoginTask { get; private set; }

    public LoginPageViewModel(ILoginService loginService)
    {
        _loginService = loginService;
        LoginCommand = new RelayCommand(() =>
        {
                LoginTask = loginService.LoginAsync("", "");
                LoginTask.GetAwaiter().OnCompleted((() =>
                {
                    OnPropertyChanged(nameof(LoginTask));
                    OnPropertyChanged(nameof(CanExecuteLogin));
                }));
                OnPropertyChanged(nameof(LoginTask));
                OnPropertyChanged(nameof(CanExecuteLogin));
        }, () => LoginTask?.IsCompleted ?? true);
    }
    
    public ICommand LoginCommand { get; }
}