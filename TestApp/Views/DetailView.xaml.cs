using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using TestApp.DIConfigureServices;
using TestApp.ViewModels;

namespace TestApp.Views;

public partial class DetailView : ContentPageBaseView
{
    public DetailViewModel DetailVM => Startup.ServiceProvider.GetService<DetailViewModel>()!;
    public DetailView()
    {
        try
        {
            InitializeComponent();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
}