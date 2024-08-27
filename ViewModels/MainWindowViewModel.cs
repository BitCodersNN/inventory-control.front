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
    private ViewModelBase _displayedPage;
    public ViewModelBase DisplayedPage
    {
        get => _displayedPage;
        private set => SetProperty(ref _displayedPage, value);
    }
    
}
