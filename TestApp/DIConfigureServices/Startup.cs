using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TestApp.services;
using TestApp.ViewModels;

namespace TestApp.DIConfigureServices;

public static class Startup
{
    public static IServiceProvider ServiceProvider { get; set; }

    /// <summary>
    ///     This is dependency injection in xamarin forms. we are using Microsoft DependencyInjection.
    ///     "Init" method needs to be called on "App.cs" After we "InitializeComponent" but before you load your first page.
    /// </summary>
    public static void Init()
    {
        try
        {
            var host = new HostBuilder().ConfigureHostConfiguration(c => { }).ConfigureServices(ConfigureServices)
                .Build();
            ServiceProvider = host.Services;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        #region Services

        #region CommonServices

        services.AddTransient<IPopupService, PopupService>();
        #endregion CommonServices

        services.AddTransient<IUserService, UserService>();
        #endregion Services

        #region ViewModel

        /// <summary> 
        ///  add the ViewModel, but as a Transient, which means it will create a new one each time.
        /// </summary>

        services.AddSingleton<LoginViewModel>();
        services.AddSingleton<HomeViewModel>();
        services.AddSingleton<DetailViewModel>();
        services.AddSingleton<ProfileViewModel>();
        
        #endregion ViewModel

        #region AppcenterConfiguration For Tracking Events

        #endregion AppcenterConfiguration For Tracking Events

        #region Delegate

        #endregion Delegate
    }
}