using System.Text.Json.Serialization;

namespace BailuTools.Core.Web.JsonNode;

public class NameToken {
    [JsonPropertyName("name")]
    public string Name { get; set; } = default!;

    [JsonPropertyName("token")]
    public string Token { get; set; } = default!;

}
