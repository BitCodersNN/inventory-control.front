using System.Collections.Generic;
using System.Windows.Input;
using Avalonia.Metadata;
using CommunityToolkit.Mvvm.Input;

namespace inventory_control.front.ViewModels;

public abstract class PageStackViewModelBase : ViewModelBase, IPageNavigator
{
    protected PageStackViewModelBase()
    {
        PopPageCommand = new RelayCommand(() => PopPage(), () => PageStack.Count > 1);
    }
    
    protected readonly Stack<ViewModelBase> PageStack = new Stack<ViewModelBase>();

    protected void PushPage(ViewModelBase page)
    {
        PageStack.Push(page);
    }

    protected ViewModelBase PopPage()
    {
        return PageStack.Pop();
    }

    public ICommand PopPageCommand { get; }

    public ViewModelBase DisplayedPage
    {
        get => PageStack.Peek();
        protected set => throw new System.NotImplementedException();
    }
}