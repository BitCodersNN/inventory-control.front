using System.Collections.Generic;
using System.Windows.Input;
using Avalonia.Metadata;
using CommunityToolkit.Mvvm.Input;

namespace inventory_control.front.ViewModels;

public abstract class PageStackViewModelBase : PageNavigationViewModelBase
{
    protected PageStackViewModelBase()
    {
        PopPageCommand = new RelayCommand(() => PopPage(), () => PageStack.Count > 1);
    }

    protected readonly Stack<PageViewModelBase> PageStack = new Stack<PageViewModelBase>();

    protected void PushPage(PageViewModelBase page)
    {
        PageStack.Push(page);
    }

    protected PageViewModelBase PopPage()
    {
        return PageStack.Pop();
    }

    public ICommand PopPageCommand { get; }

    public override PageViewModelBase DisplayedPage
    {
        get => PageStack.Peek();
        protected set => throw new System.NotImplementedException();
    }
}