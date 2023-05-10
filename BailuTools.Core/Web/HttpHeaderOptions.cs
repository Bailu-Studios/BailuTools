namespace BailuTools.Core.Web;

public static class HttpHeaderOptions {
    
    /// <summary>
    /// Json请求类型
    /// </summary>
    private const string ApplicationJson = "application/json";

    /// <summary>
    /// 米游社请求UA
    /// </summary>
    public const string UserAgent = $"Mozilla/5.0 (Windows NT 10.0; Win64; x64) miHoYoBBS/{XrpcVersion}";

    /// <summary>
    /// 米游社 Rpc 版本
    /// </summary>
    public const string XrpcVersion = "2.49.1";
    
    /// <summary>
    /// 米游社设备Id
    /// deviceId ??= Guid.NewGuid().ToString())
    /// </summary>
    private static string? deviceId;
    
    public static void XRpc2Configuration(this HttpClient client) {
        client.Timeout = Timeout.InfiniteTimeSpan;
        client.DefaultRequestHeaders.UserAgent.ParseAdd(UserAgent);
        client.DefaultRequestHeaders.Accept.ParseAdd(ApplicationJson);
        client.DefaultRequestHeaders.Add("x-rpc-aigis", string.Empty);
        client.DefaultRequestHeaders.Add("x-rpc-app_id", "bll8iq97cem8");
        client.DefaultRequestHeaders.Add("x-rpc-app_version", XrpcVersion);
        client.DefaultRequestHeaders.Add("x-rpc-client_type", "2");
        client.DefaultRequestHeaders.Add("x-rpc-device_id", deviceId ??= Guid.NewGuid().ToString());
        client.DefaultRequestHeaders.Add("x-rpc-game_biz", "bbs_cn");
        client.DefaultRequestHeaders.Add("x-rpc-sdk_version", "1.3.1.2");
    }
}
