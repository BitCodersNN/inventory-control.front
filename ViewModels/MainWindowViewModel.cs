using System;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.Net.Mime;
using Avalonia;
using inventory_control.front.Services.Interfaces;
using inventory_control.front.ViewModels.Pages;

namespace inventory_control.front.ViewModels;

public class MainWindowViewModel : ViewModelBase, IPageNavigator
{
    private readonly ILoginService _loginService;

    private ViewModelBase _displayedPage;

    public MainWindowViewModel(ILoginService loginService)
    {
        _loginService = loginService;
        _displayedPage = GetDisplayedPage();
        _loginService.PropertyChanged += (sender, args) =>
        {
            switch (args.PropertyName)
            {
                case nameof(ILoginService.IsLoggedIn):
                    DisplayedPage = GetDisplayedPage();
                    break;
            }
        };
    }

    private ViewModelBase GetDisplayedPage()
    {
        if (_loginService.IsLoggedIn)
        {
            var mainPageViewModel = GetService<MainPageViewModel>();
            return mainPageViewModel;
        }

        return GetService<LoginPageViewModel>();
    }
    public ViewModelBase DisplayedPage
    {
        get => _displayedPage;
        private set => SetProperty(ref _displayedPage, value);
    }

}
