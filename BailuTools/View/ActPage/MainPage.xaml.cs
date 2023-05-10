using System.Diagnostics;
using BailuTools.Core.Test;
using BailuTools.ViewModel;
using Microsoft.UI.Xaml;
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

    public void BtnClick(object sender, RoutedEventArgs e) {
    }
}
