using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using Godot;
using JiraTempoAppGodot.ApiModels.Jira;
using JiraTempoAppGodot.ApiModels.Tempo;
using Newtonsoft.Json;
using HttpClient = System.Net.Http.HttpClient;

namespace JiraTempoAppGodot.Services;

public class TempoService : IService
{
    private const string Host = "https://api.tempo.io";
    private const int ApiVersion = 4;
    private readonly HttpClient _httpClient;

    public TempoService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public AuthorizeResponse ExecuteLogin()
    {
        var settings = Settings.Load();

        const string redirectUrl = UrlCallbackServer.CallbackUrl;
        var url =
            $"{settings.Jira.Domain}/plugins/servlet/ac/io.tempo.jira/oauth-authorize/?client_id={settings.Tempo.ClientId}&redirect_uri={redirectUrl}";
        OS.ShellOpen(url);

        var code = UrlCallbackServer.WaitAndGetCodeFromQueryParam();
        GD.Print(code);

        var dict = new Dictionary<string, string>
        {
            { "grant_type", "authorization_code" },
            { "client_id", settings.Tempo.ClientId },
            { "client_secret", settings.Tempo.ClientSecret },
            { "redirect_uri", UrlCallbackServer.CallbackUrl },
            { "code", code }
        };

        using var req = new HttpRequestMessage(HttpMethod.Post, "https://api.tempo.io/oauth/token/");
        req.Content = new FormUrlEncodedContent(dict);
        using var response = _httpClient.SendAsync(req).Result;

        var dataContent = response.Content;
        var stringData = dataContent.ReadAsStringAsync().Result;
        var data = JsonConvert.DeserializeObject<AuthorizeResponse>(stringData);
        return data;
    }

    public AccountsResponse GetAccounts()
    {
        return ExecuteRequest<AccountsResponse>("accounts");
    }

    public CreateWorklogResponse CreateWorklog(CreateWorklogRequest data)
    {
        return ExecuteRequest<CreateWorklogResponse>("worklogs", data);
    }

    private T ExecuteRequest<T>(string path, object data = null) where T : class
    {
        var settings = Settings.Load();

        var url = $"{Host}/{ApiVersion}/{path}";
        _httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", settings.Tempo.AccessToken);

        HttpResponseMessage response = null;

        if (data is null)
        {
            response = _httpClient.GetAsync(url).Result;
        }
        else
        {
            var dataStringRequest = JsonConvert.SerializeObject(data);
            var content = new StringContent(dataStringRequest);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            response = _httpClient.PostAsync(url, content).Result;
        }

        var dataString = response.Content.ReadAsStringAsync().Result;
        return JsonConvert.DeserializeObject<T>(dataString);
    }

    public WorklogsResponse GetWorklogs()
    {
        return ExecuteRequest<WorklogsResponse>("worklogs?from=2022-01-28&to=2024-02-03");
    }
}