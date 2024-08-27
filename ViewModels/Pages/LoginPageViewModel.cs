using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using inventory_control.front.Services.Interfaces;
using LanguageExt.Common;

namespace inventory_control.front.ViewModels.Pages;

public class LoginPageViewModel : ViewModelBase
{
    private readonly ILoginService _loginService;
    private string _errorText;
    public bool CanExecuteLogin => LoginCommand.CanExecute(null);
    public Task<Result<bool>>? LoginTask { get; private set; }

    public LoginPageViewModel(ILoginService loginService)
    {
        _loginService = loginService;
        LoginCommand = new RelayCommand(() =>
        {
            ErrorText = "";
                LoginTask = loginService.LoginAsync(LoginText, PasswordText);
                LoginTask.GetAwaiter().OnCompleted(() =>
                {
                    LoginTask.Result.IfSucc(b => { ErrorText = b ? "" : "Неправильный пароль"; });
                    LoginTask.Result.IfFail(e => ErrorText = $"Ошибка: {e}");
                    OnPropertyChanged(nameof(LoginTask));
                    OnPropertyChanged(nameof(CanExecuteLogin));
                });
                OnPropertyChanged(nameof(LoginTask));
                OnPropertyChanged(nameof(CanExecuteLogin));
        }, () => LoginTask?.IsCompleted ?? true);
    }

    public string LoginText { get; set; } = "";
    public string PasswordText { get; set; } = "";

    public bool SavePassword { get; set; } = false;

    public ICommand LoginCommand { get; }

    public string ErrorText
    {
        get => _errorText;
        set
        {
            if (SetProperty(ref _errorText, value)) OnPropertyChanged(nameof(ShowError));
        }
    }

    public bool ShowError => ErrorText != "";
}