using System;
using CommunityToolkit.Maui.Views;

namespace TestApp.Views;

public partial class CommonPopup : Popup
{
    public CommonPopup(string _title, string _message)
    {
        InitializeComponent();
        title.Text = _title;
        message.Text = _message;
    }

    private void Button_OnClicked(object? sender, EventArgs e)
    {
        Close();
    }
}