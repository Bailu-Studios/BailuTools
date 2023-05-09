using BailuTools.ViewModel;

using Microsoft.UI.Xaml.Controls;

namespace BailuTools.View;

// To learn more about WebView2, see https://docs.microsoft.com/microsoft-edge/webview2/.
public sealed partial class HoyoLabPage : Page
{
    public HoyoLabViewModel ViewModel
    {
        get;
    }

    public HoyoLabPage()
    {
        ViewModel = App.GetService<HoyoLabViewModel>();
        InitializeComponent();

        ViewModel.WebViewService.Initialize(WebView);
    }
}
