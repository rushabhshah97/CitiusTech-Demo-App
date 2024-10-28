using System;
using CommunityToolkit.Maui.Views;
using Microsoft.Maui.Controls;

namespace TestApp.services;

public class PopupService : IPopupService
{
    public void ShowPopup(Popup popup)
    {
        Page page = Application.Current?.MainPage ?? throw new NullReferenceException();
        page.ShowPopup(popup);
    }
}