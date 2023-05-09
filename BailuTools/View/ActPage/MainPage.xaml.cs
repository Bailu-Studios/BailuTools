using BailuTools.ViewModel;

using Microsoft.UI.Xaml.Controls;

namespace BailuTools.View.ActPage;

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
