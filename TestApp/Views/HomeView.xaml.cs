using Microsoft.Extensions.DependencyInjection;
using TestApp.DIConfigureServices;
using TestApp.ViewModels;

namespace TestApp.Views;

public partial class HomeView : ContentPageBaseView
{
    public HomeViewModel HomeVM => Startup.ServiceProvider.GetService<HomeViewModel>()!;
    public HomeView()
    {
        InitializeComponent();
    }
}