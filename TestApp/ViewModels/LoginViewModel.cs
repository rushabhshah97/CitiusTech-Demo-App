using System;
using System.Text.RegularExpressions;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Maui.Controls;
using TestApp.Common;
using TestApp.Models;
using TestApp.services;
using TestApp.Views;

namespace TestApp.ViewModels;

public partial class LoginViewModel : BaseViewModel
{
    #region Constructor

    public LoginViewModel(IPopupService popupService, IUserService _userService) : base(popupService)
    {
        this._userService = _userService;
    }

    #endregion

    #region Commands

    public ICommand LoginAsyncCommand => new Command(Login, () => !IsBusy);

    #endregion

    #region Methods

    /// <summary>
    /// Login Tap Command
    /// </summary>
    public async void Login()
    {
        try
        {
            IsBusy = true;
            if (!CredentialsAreValid()) return;

            UserProfile userProfile = new(NickName, Email);
            _userService.SaveUserData(userProfile);

            if (Application.Current?.MainPage != null)
                Application.Current.MainPage = new NavigationPage(new BottomView());
        }
        catch (Exception exception)
        {
            PopupService.ShowPopup(new CommonPopup("Alert", "An error occurred while logging in. Please try again."));
            Console.WriteLine("Error while logging in." + exception.Message);
        }
        finally
        {
            IsBusy = false;
        }
    }

    /// <summary>
    /// Check whether the credentials are valid or not
    /// </summary>
    /// <returns>If it is valid will return true else false</returns>
    private bool CredentialsAreValid()
    {
        if (string.IsNullOrEmpty((NickName)) || string.IsNullOrEmpty((Email)) || string.IsNullOrEmpty(Password))
        {
            PopupService.ShowPopup(new CommonPopup("Alert", "Please, enter your credentials"));
            return false;
        }

        else if (!Regex.IsMatch(Email, Constants.EmailRegex))
        {
            PopupService.ShowPopup(new CommonPopup("Alert", "Please enter valid email address"));
            return false;
        }

        else if (Password.Length < 6)
        {
            PopupService.ShowPopup(new CommonPopup("Alert", "Please enter password which is longer than 6 characters"));
            return false;
        }

        return true;
    }

    #endregion

    #region Properties

    private IUserService _userService;
    [ObservableProperty] private string _nickName;
    [ObservableProperty] private string _email;
    [ObservableProperty] private string _password;

    #endregion
}