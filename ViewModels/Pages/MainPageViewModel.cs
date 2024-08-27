using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using inventory_control.front.Services.Interfaces;
using inventory_control.front.ViewModels.Pages.MainPage;
using inventory_control.front.ViewModels.Pages.MainPage.Utility;

namespace inventory_control.front.ViewModels.Pages;



public class MainPageViewModel : ViewModelBase, IPageNavigator
{
    private ILoginService _loginService;

    private int _selectedPageIndex = 0;

    public int SelectedPageIndex
    {
        get => _selectedPageIndex;
        set
        {
            if (SetProperty(ref _selectedPageIndex, value)) OnPropertyChanged(nameof(DisplayedPage));
        }
    }


    public MainPageViewModel(ILoginService loginService)
    {
        _loginService = loginService;
        if (_loginService.CurrentUser != null)
        {
            Pages = PagesListFactory.GetPagesForUser(loginService.CurrentUser!);
        }
    }

    public List<ViewModelBase> Pages { get; } = [];
    
    

    public ViewModelBase DisplayedPage => Pages[SelectedPageIndex];

}