using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.DependencyInjection;
using TestApp.DIConfigureServices;
using TestApp.Models;
using TestApp.services;

namespace TestApp.ViewModels;

public partial class DetailViewModel(IPopupService popupService) : BaseViewModel(popupService)
{
    #region Service Instance
    public HomeViewModel HomeVM => Startup.ServiceProvider.GetService<HomeViewModel>()!;
    #endregion
    
    #region Properties

    [ObservableProperty] public BookData _selectedBook;
    
    #endregion

    #region Constructor

    #endregion
    
}