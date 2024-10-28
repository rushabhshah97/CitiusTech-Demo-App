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

public partial class ProfileViewModel : BaseViewModel
{
    #region Constructor

    public ProfileViewModel(IPopupService popupService, IUserService userService) : base(popupService)
    {
        UserService = userService;
    }

    #endregion

    #region Commands

    public ICommand OnAppearingCommand
    {
        get { return new Command(OnAppearing, canExecute: () => !IsBusy); }
    }

    public ICommand ChangeEditModelCommand
    {
        get { return new Command(() => { IsEditMode = !IsEditMode; }, () => !IsBusy); }
    }

    public ICommand SaveUserDataCommand
    {
        get { return new Command(SaveUserData, () => !IsBusy); }
    }

    #endregion

    #region Methods

    /// <summary>
    /// Check whether the credentials are valid or not
    /// </summary>
    /// <returns>If it is valid will return true else false</returns>
    private bool CredentialsAreValid()
    {
        if (string.IsNullOrEmpty(UserData?.NickName) || string.IsNullOrEmpty(UserData.Email))
        {
            PopupService.ShowPopup(new CommonPopup("Alert", "Please, enter your data"));
            return false;
        }

        else if (!Regex.IsMatch(UserData.Email, Constants.EmailRegex))
        {
            PopupService.ShowPopup(new CommonPopup("Alert", "Please enter valid email address"));
            return false;
        }

        return true;
    }

    private void SaveUserData()
    {
        try
        {
            IsBusy = true;
            if (!CredentialsAreValid())
                return;
            UserService.SaveUserData(UserData!);
            PopupService.ShowPopup(new CommonPopup("Alert", "User Data is saved"));
            IsEditMode = false;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        finally
        {
            IsBusy = false;
        }
    }

    private async void OnAppearing()
    {
        try
        {
            IsBusy = true;
            UserData = UserService.GetUserData();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        finally
        {
            IsBusy = false;
        }
    }

    #endregion

    #region Properties

    private IUserService UserService;
    [ObservableProperty] private bool _isEditMode;
    [ObservableProperty] private UserProfile? _userData;

    #endregion
}