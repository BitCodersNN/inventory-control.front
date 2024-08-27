using inventory_control.front.ViewModels.Pages.MainPage;

namespace inventory_control.front.ViewModels.Pages;

public class MainPageViewModel : ViewModelBase, IPageNavigator
{
    public ViewModelBase DisplayedPage => GetService<DataEntryPageViewModel>();
    
}