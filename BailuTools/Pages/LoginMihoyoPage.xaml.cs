using BailuTools.ViewModels;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.Web.WebView2.Core;

namespace BailuTools.Pages;

internal sealed partial class LoginMihoyoPage : Page {
    public LoginMihoyoViewModel ViewModel
    {
        get;
    }

    public LoginMihoyoPage()
    {
        ViewModel = App.GetService<LoginMihoyoViewModel>();
        InitializeComponent();
    }
    
    private async void OnRootLoaded(object sender, RoutedEventArgs e)
    {
        try
        {
            await WebView.EnsureCoreWebView2Async();

            var manager = WebView.CoreWebView2.CookieManager;
            IReadOnlyList<CoreWebView2Cookie> cookies = await manager.GetCookiesAsync("https://user.mihoyo.com");
            foreach (var item in cookies)
            {
                manager.DeleteCookie(item);
            }

            WebView.CoreWebView2.Navigate("https://user.mihoyo.com/#/login/password");
        }
        catch (Exception ex)
        {
            // Ioc.Default.GetRequiredService<IInfoBarService>().Error(ex);
        }
    }
    
    private void CookieButtonClick(object sender, RoutedEventArgs e)
    {
        
    }
}
