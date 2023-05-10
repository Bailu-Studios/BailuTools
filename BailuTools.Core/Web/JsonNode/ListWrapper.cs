using System.Text.Json.Serialization;

namespace BailuTools.Core.Web.JsonNode;

public class ListWrapper<T> {
    [JsonPropertyName("list")]
    public List<T> List { get; set; } = default!;
}
