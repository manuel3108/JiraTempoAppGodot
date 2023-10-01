using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Godot;
using JiraTempoAppGodot.ApiModels.Jira;
using Newtonsoft.Json;
using HttpClient = System.Net.Http.HttpClient;

namespace JiraTempoAppGodot.Services;

public class JiraService : IService
{
    private const string Host = "https://api.atlassian.com";
    private const string ApiPath = "ex/jira";
    private const string ApiSubPath = "rest/api";
    private const int ApiVersion = 3;
    private const string GrantTypeAuthorizationCode = "authorization_code";
    private const string GrantTypeRefreshToken = "refresh_token";
    private readonly HttpClient _httpClient;

    public JiraService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public AuthorizeResponse ExecuteLogin()
    {
        var settings = Settings.Load();

        const string redirectUrl = UrlCallbackServer.CallbackUrl;
        var url =
            $"https://auth.atlassian.com/authorize?audience=api.atlassian.com&client_id={settings.Jira.ClientId}&scope=read%3Ajira-work%20read%3Ajira-user%20read%3Aissue-details%3Ajira%20offline_access&redirect_uri={redirectUrl}&state=YOUR_USER_BOUND_VALUE&response_type=code&prompt=consent";
        OS.ShellOpen(url);

        var code = UrlCallbackServer.WaitAndGetCodeFromQueryParam();
        GD.Print(code);

        var data = Authorize(code, GrantTypeAuthorizationCode);
        return data;
    }

    private AuthorizeResponse Authorize(string code, string grantType)
    {
        var settings = Settings.Load();

        var authRequest = new AuthorizeRequest
        {
            Code = grantType == GrantTypeAuthorizationCode ? code : null,
            RefreshToken = grantType == GrantTypeRefreshToken ? code : null,
            ClientId = settings.Jira.ClientId,
            ClientSecret = settings.Jira.ClientSecret,
            GrantType = grantType,
            RedirectUri = UrlCallbackServer.CallbackUrl
        };

        var httpContent = new StringContent(JsonConvert.SerializeObject(authRequest));
        httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        var response = _httpClient.PostAsync("https://auth.atlassian.com/oauth/token", httpContent).Result;
        var dataContent = response.Content;
        var stringData = dataContent.ReadAsStringAsync().Result;

        var data = JsonConvert.DeserializeObject<AuthorizeResponse>(stringData);
        return data;
    }

    public IEnumerable<AvailableResourcesResponse> GetAccessibleResources()
    {
        var settings = Settings.Load();

        _httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", settings.Jira.AccessToken);
        var response = _httpClient.GetAsync("https://api.atlassian.com/oauth/token/accessible-resources").Result;
        var dataContent = response.Content;
        var stringData = dataContent.ReadAsStringAsync().Result;
        var data = JsonConvert.DeserializeObject<List<AvailableResourcesResponse>>(stringData);

        return data;
    }

    public SearchIssuesResponse SearchIssues(string query)
    {
        return ExecuteRequest<SearchIssuesResponse>($"issue/picker?query={query}&currentJQL=");
    }

    private T ExecuteRequest<T>(string path) where T : class
    {
        var settings = Settings.Load();

        var url = $"{Host}/{ApiPath}/{settings.Jira.CloudId}/{ApiSubPath}/{ApiVersion}/{path}";

        _httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", settings.Jira.AccessToken);
        var response = _httpClient.GetAsync(url).Result;

        if (response.IsSuccessStatusCode)
        {
            var dataString = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<T>(dataString);
        }

        if (response.StatusCode != HttpStatusCode.Unauthorized)
            return null;

        var authorizeResponse = Authorize(settings.Jira.RefreshToken, GrantTypeRefreshToken);
        settings.Jira.AccessToken = authorizeResponse.AccessToken;
        settings.Jira.RefreshToken = authorizeResponse.RefreshToken;
        settings.Jira.ExpiresIn = authorizeResponse.ExpiresIn;
        settings.Save();

        _httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", settings.Jira.AccessToken);
        response = _httpClient.GetAsync(url).Result;
        var dataString2 = response.Content.ReadAsStringAsync().Result;
        return JsonConvert.DeserializeObject<T>(dataString2);
    }
}