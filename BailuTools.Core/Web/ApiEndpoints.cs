namespace BailuTools.Core.Web;

/// <summary>
/// 国服 API 端点
/// </summary>
internal static class ApiEndpoints
{
    
    /// <summary>
    /// 获取 stoken 与 ltoken
    /// </summary>
    /// <param name="loginTicket">登录票证</param>
    /// <param name="loginUid">uid</param>
    /// <returns>Url</returns>
    public static string AuthMultiToken(string loginTicket, string loginUid) => 
        $"{ApiTakumiAuthApi}/getMultiTokenByLoginTicket?login_ticket={loginTicket}&uid={loginUid}&token_types=3";
    
    
    /// <summary>
    /// 获取V2SToken
    /// </summary>
    public const string AccountGetSTokenByOldToken = $"{PassportApi}/account/ma-cn-session/app/getTokenBySToken";
    
    private const string ApiTakumi = "https://api-takumi.mihoyo.com";
    private const string ApiTakumiAuthApi = $"{ApiTakumi}/auth/api";
    
    private const string PassportApi = "https://passport-api.mihoyo.com";

}