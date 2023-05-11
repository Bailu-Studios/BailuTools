using System.Diagnostics;
using BailuTools.Core.Web;
using Microsoft.UI.Xaml.Controls;

namespace BailuTools.Core.Service;

public static class MhyTokenService {
    private static readonly AuthClient _client = new();

    public static async Task HandleCurrentCookieAsync(WebView2 webView, CancellationToken token = default) {
        try {
            var manager = webView.CoreWebView2.CookieManager;
            
            var cookies = await manager.GetCookiesAsync("https://user.mihoyo.com");
            var ticketCookie = Cookie.FromCoreWebView2Cookies(cookies);
            var tokenResponse = await _client
                .GetMultiTokenByLoginTicketAsync(ticketCookie, token)
                .ConfigureAwait(false);
            
            if (!tokenResponse.IsOk()) return;
            
            var multiTokenMap = tokenResponse.Data!.List.ToDictionary(n => n.Name, n => n.Token);
            var stokenV1 = Cookie.FromSToken(ticketCookie[Cookie.LOGIN_UID], multiTokenMap[Cookie.STOKEN]);
            var loginResultResponse = await _client
                .LoginBySTokenAsync(stokenV1, token)
                .ConfigureAwait(false);
            if (!loginResultResponse.IsOk()) return;
            
            var stokenV2 = Cookie.FromLoginResult(loginResultResponse.Data);
            var mid = stokenV2.GetValueOrDefault(Cookie.MID);
            stokenV2.TryGetSToken(out Cookie? stoken);

            Debug.WriteLine(stoken); // TODO 写入到用户数据库
            Debug.WriteLine(stokenV2.TryGetLToken(out Cookie? ltoken) ? ltoken : "Null LToken");
            Debug.WriteLine(stokenV2.TryGetCookieToken(out Cookie? cookieToken) ? cookieToken : "Null Cookie Token");
        } catch (KeyNotFoundException) {
            Debug.WriteLine("未登录"); // TODO 弹出窗口提示
            throw;
        }catch (Exception e) {
            Debug.WriteLine(e);
            throw;
        }
    }

}
