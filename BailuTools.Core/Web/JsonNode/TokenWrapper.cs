using System.Text.Json.Serialization;

namespace BailuTools.Core.Web.JsonNode;

/// <summary>
/// Stoken包装
/// </summary>
public sealed class TokenWrapper
{
    /// <summary>
    /// Stoken的类型为 1
    /// </summary>
    [JsonPropertyName("token_type")]
    public int TokenType { get; set; }

    /// <summary>
    /// Stoken
    /// </summary>
    [JsonPropertyName("token")]
    public string Token { get; set; } = default!;
}