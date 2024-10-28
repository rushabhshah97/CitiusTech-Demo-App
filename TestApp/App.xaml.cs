using System;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Storage;
using Newtonsoft.Json;
using TestApp.Common;
using TestApp.Controls;
using TestApp.DIConfigureServices;
using TestApp.Models;
using TestApp.Views;

namespace TestApp;

public partial class App : Application
{
    public App()
    {
        try
        {
            DependencyInjectionInit();

            InitializeComponent();
            var userProfileData = Preferences.Get(Constants.UserProfileKey, string.Empty);
            if (string.IsNullOrWhiteSpace(userProfileData))
                MainPage = new NavigationPage(new LoginView());
            else
            {
                var userProfile = JsonConvert.DeserializeObject<UserProfile>(userProfileData);
                if (userProfile == null)
                    MainPage = new NavigationPage(new LoginView());
                else
                {
                    MainPage = new BottomView();
                }
            }

            Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping(nameof(IView.Background), (h, v) =>
            {
                if (v is not BorderEntry) return;
#if ANDROID
                    float[] outerRadii = { 10, 10, 10, 10, 10, 10, 10, 10 };
                    Android.Graphics.Drawables.Shapes.RoundRectShape roundRectShape =
                        new Android.Graphics.Drawables.Shapes.RoundRectShape(outerRadii, null, null);
                    var shape = new Android.Graphics.Drawables.ShapeDrawable(roundRectShape);
                    shape.Paint.Color = Android.Graphics.Color.Gray;
                    shape.Paint.StrokeWidth = 3;
                    shape.Paint.SetStyle(Android.Graphics.Paint.Style.Stroke);
                    h.PlatformView.Background = shape;
#elif IOS
                h.PlatformView.Layer.BorderColor = UIKit.UIColor.Gray.CGColor;
                h.PlatformView.BorderStyle = UIKit.UITextBorderStyle.RoundedRect;
#endif
            });
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }

    /// <summary>
    ///     Initialize DependencyInjection
    /// </summary>
    public void DependencyInjectionInit()
    {
        try
        {
            Startup.Init();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
}