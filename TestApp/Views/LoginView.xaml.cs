using Microsoft.Extensions.DependencyInjection;
using TestApp.DIConfigureServices;
using TestApp.ViewModels;

namespace TestApp.Views;

public partial class LoginView : ContentPageBaseView
{
    public LoginViewModel LoginVM => Startup.ServiceProvider.GetService<LoginViewModel>();
    public LoginView()
    {
        InitializeComponent();
    }
}