using System.Text.Json.Serialization;

namespace BailuTools.Core.Web.JsonNode;

/// <summary>
/// 登录结果
/// </summary>
public class LoginResult
{
    /// <summary>
    /// SToken 包装
    /// </summary>
    [JsonPropertyName("token")]
    public TokenWrapper Token { get; set; } = default!;

    /// <summary>
    /// 用户信息
    /// </summary>
    [JsonPropertyName("user_info")]
    public UserInformation UserInfo { get; set; } = default!;

    /// <summary>
    /// 重激活信息
    /// </summary>
    [JsonPropertyName("reactivate_info")]
    public ReactivateInfo ReactivateInfo { get; set; } = default!;

    /// <summary>
    /// Dangerous login ticket
    /// </summary>
    [JsonPropertyName("login_ticket")]
    public string LoginTicket { get; set; } = default!;
}