using inventory_control.front.Models;
using inventory_control.front.Services.Interfaces;

namespace inventory_control.front.ViewModels.Pages.MainPage;

public class DataEntryPageViewModel : ViewModelBase
{
    private readonly ILoginService _loginService;

    public override string Title => "Ввод данных";

    public DataEntryPageViewModel(ILoginService loginService)
    {
        _loginService = loginService;
    }

}