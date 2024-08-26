namespace inventory_control.front.ViewModels;

public abstract class PageNavigationViewModelBase : ViewModelBase
{
    public abstract PageViewModelBase DisplayedPage { get; protected set; }
    
}