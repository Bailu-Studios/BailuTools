using BailuTools.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace BailuTools.Views;

public sealed partial class MainPage : Page
{
    public MainViewModel ViewModel
    {
        get;
    }

    public MainPage()
    {
        ViewModel = App.GetService<MainViewModel>();
        InitializeComponent();
    }
}
