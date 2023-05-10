using System.Text.Json.Serialization;

namespace BailuTools.Core.Web.JsonNode;

/// <summary>
/// 链接
/// </summary>
public sealed class Link
{
    /// <summary>
    /// 第三方 sn
    /// </summary>
    [JsonPropertyName("thirdparty")]
    public string Thirdparty { get; set; } = default!;

    /// <summary>
    /// Union Id
    /// </summary>
    [JsonPropertyName("union_id")]
    public string UnionId { get; set; } = default!;

    /// <summary>
    /// 昵称
    /// </summary>
    [JsonPropertyName("nickname")]
    public string Nickname { get; set; } = default!;
}
