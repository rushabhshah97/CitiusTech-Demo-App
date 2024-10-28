using System;
using System.Collections.Generic;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using TestApp.DIConfigureServices;
using TestApp.ViewModels;

namespace TestApp.Views;

public partial class ContentPageBaseView : ContentPage
{
    #region Constructor

    public ContentPageBaseView()
    {
        try
        {
            InitializeComponent();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    #endregion Constructor

    public BaseViewModel BaseVM => Startup.ServiceProvider.GetService<BaseViewModel>()!;

    #region BasePageContent

    public IList<IView> BasePageContent => BaseContentGrid.Children;

    #endregion BasePageContent

    #region Bindable Properties

    #endregion

    #region Methods

    #endregion Methods
}