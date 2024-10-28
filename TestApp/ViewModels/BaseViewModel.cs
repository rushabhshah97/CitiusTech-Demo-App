using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using Microsoft.Maui.Controls;
using TestApp.services;
using TestApp.Views;

namespace TestApp.ViewModels;

public partial class BaseViewModel : ObservableObject
{
    #region Properties

    [ObservableProperty] private bool _isBusy;

    public IPopupService PopupService;

    #endregion

    #region Constructor

    public BaseViewModel(IPopupService popupService)
    {
        this.PopupService = popupService;
    }

    #endregion

    #region Service Instances

    public INavigation NavigationService => Application.Current.MainPage.Navigation;

    #endregion

    #region Commands

    public ICommand OnAppearingMasterCommand => new Command<object>(obj =>
    {
        Console.WriteLine(("OnAppearingMasterCommand"));
    });

    public ICommand LogoutCommand => new Command(() =>
    {
        Preferences.Clear();
        if (Application.Current != null) Application.Current.MainPage = new LoginView();
    }, canExecute: () => !IsBusy);

    public ICommand GoToBackCommand => new Command(() =>
    {
        NavigationService.PopModalAsync();
    }, () => !IsBusy);

    #endregion
}