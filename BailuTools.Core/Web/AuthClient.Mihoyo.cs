using System.Net.Http.Json;
using System.Text.Json;
using BailuTools.Core.Extension;
using BailuTools.Core.Web.JsonNode;

namespace BailuTools.Core.Web;

public sealed partial class AuthClient {
    private readonly JsonSerializerOptions options = new ();
    private readonly HttpClient _httpClient;
    
    public AuthClient() {
        _httpClient = new HttpClient();
        _httpClient.XRpc2Configuration();
    }
    
    public async Task<Response<ListWrapper<NameToken>>> GetMultiTokenByLoginTicketAsync(Cookie cookie, CancellationToken token)
    {
        var loginTicket = cookie[Cookie.LOGIN_TICKET];
        var loginUid = cookie[Cookie.LOGIN_UID];

        var url = ApiEndpoints.AuthMultiToken(loginTicket, loginUid);

        var resp = await _httpClient
            .TryCatchGetFromJsonAsync<Response<ListWrapper<NameToken>>>(url, options, token)
            .ConfigureAwait(false);
        return Response.DefaultIfNull(resp);
    }
    
    public async Task<Response<LoginResult>> LoginBySTokenAsync(Cookie stokenV1, CancellationToken token)
    {
        var message = await _httpClient
            .SetHeader("Cookie", stokenV1.ToString())
            .UseDynamicSecret()
            .PostAsync(ApiEndpoints.AccountGetSTokenByOldToken, null, token)
            .ConfigureAwait(false);

        var resp = await message.Content
            .ReadFromJsonAsync<Response<LoginResult>>(options, token)
            .ConfigureAwait(false);

        return Response.DefaultIfNull(resp);
    }
    

}
