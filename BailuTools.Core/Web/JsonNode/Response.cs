using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace BailuTools.Core.Web.JsonNode;

public class Response {
    [JsonPropertyName("retcode")]
    public int ReturnCode { get; set; }

    [JsonPropertyName("message")]
    public string Message { get; set; }

    public Response(int returnCode, string message) {
        ReturnCode = returnCode;
        Message = message;
    }
    
    public static Response<TData> DefaultIfNull<TData>(Response<TData>? response, string callerName = default!) {
        // 4A970F73 is a magic number that hashed from "BailuTools"
        return response ?? new Response<TData>(0x4A970F73, $"[{callerName}] 中的 [{typeof(TData).Name}] 网络请求异常，请稍后再试", default);
    }

    public bool IsOk() {
        return ReturnCode == 0;
    }

}

public class Response<TData> : Response {
    [JsonPropertyName("data")]
    public TData? Data { get; set; }

    [JsonConstructor]
    public Response(int returnCode, string message, TData? data) : base(returnCode, message) {
        Data = data;
    }

}
