using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

namespace BailuTools.Core.Extension;

public static class HttpClientExtension {
    internal static async Task<T?> TryCatchGetFromJsonAsync<T>(this HttpClient httpClient, string requestUri, JsonSerializerOptions options, CancellationToken token = default)
        where T : class
    {
        try {
            return await httpClient.GetFromJsonAsync<T>(requestUri, options, token).ConfigureAwait(false);
        } catch (Exception) {
            return null;
        }
    }

    public static void Set(this HttpRequestHeaders headers, string name, string? value) {
        headers.Remove(name);
        headers.Add(name, value);
    }
    
    internal static HttpClient SetHeader(this HttpClient httpClient, string key, string value) {
        httpClient.DefaultRequestHeaders.Set(key, value);
        return httpClient;
    }
    
    public static HttpClient UseDynamicSecret(this HttpClient client) {
        client.DefaultRequestHeaders.Set("DS-Option", $"Gen2|PROD|True");
        return client;
    }
}
