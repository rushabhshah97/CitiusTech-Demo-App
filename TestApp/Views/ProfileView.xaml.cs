using Microsoft.Extensions.DependencyInjection;
using TestApp.DIConfigureServices;
using TestApp.ViewModels;

namespace TestApp.Views;

public partial class ProfileView : ContentPageBaseView
{
    public ProfileViewModel ProfileVM => Startup.ServiceProvider.GetService<ProfileViewModel>()!;
    public ProfileView()
    {
        InitializeComponent();
    }
}