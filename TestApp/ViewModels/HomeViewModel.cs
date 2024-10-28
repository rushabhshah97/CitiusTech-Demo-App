using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Maui.Controls;
using TestApp.Common;
using TestApp.Models;
using TestApp.services;
using TestApp.Views;

namespace TestApp.ViewModels;

public partial class HomeViewModel : BaseViewModel
{
    #region Constructor

    public HomeViewModel(IPopupService popupService, IUserService userService) : base(popupService)
    {
        _userService = userService;
        BooksData = new ObservableCollection<BookData>(Constants.Books);
    }

    #endregion

    #region Commands

    public ICommand OnAppearingCommand
    {
        get { return new Command(OnAppearing, canExecute: () => !IsBusy); }
    }

    public ICommand NavigateToDetailPageCommand
    {
        get { return new Command<BookData>(NavigateToDetailPage, canExecute: (obj) => !IsBusy); }
    }

    #endregion

    #region Methods

    private void OnAppearing()
    {
        UserData = _userService.GetUserData();
    }

    private async void NavigateToDetailPage(BookData bookData)
    {
        //Navigate to Detail Page
        SelectedBookData = bookData;
        await NavigationService.PushModalAsync(new DetailView());
    }

    #endregion

    #region Properties

    private IUserService _userService;
    [ObservableProperty] private ObservableCollection<BookData> _booksData;
    [ObservableProperty] private BookData _selectedBookData;
    [ObservableProperty] private UserProfile _userData;

    #endregion
}