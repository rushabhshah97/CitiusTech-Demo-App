using System;
using Microsoft.Maui.Controls.PlatformConfiguration.AndroidSpecific;
using Microsoft.Maui.Storage;
using Application = Microsoft.Maui.Controls.Application;
using TabbedPage = Microsoft.Maui.Controls.TabbedPage;

namespace TestApp.Views;

public partial class BottomView : TabbedPage
{
    public BottomView()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        Microsoft.Maui.Controls.PlatformConfiguration.AndroidSpecific.TabbedPage.SetToolbarPlacement(this,
            ToolbarPlacement.Bottom);
    }

    private void LogoutMethod_Clicked(object? sender, EventArgs e)
    {
        Preferences.Clear();
        if (Application.Current != null)
            Application.Current.MainPage = new LoginView();
    }
}