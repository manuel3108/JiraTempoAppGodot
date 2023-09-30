using System.Collections.Generic;
using System.Net.Http;
using Godot;
using JiraTempoAppGodot;
using JiraTempoAppGodot.ApiModels.Jira;
using Newtonsoft.Json;
using HttpClient = System.Net.Http.HttpClient;

public partial class TempoLoginButton : Button
{
    public override void _Pressed()
    {
        var settings = Settings.Load();

        var redirectUrl = UrlCallbackServer.CallbackUrl;
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

        using var client = new HttpClient();
        using var req = new HttpRequestMessage(HttpMethod.Post, "https://api.tempo.io/oauth/token/");
        req.Content = new FormUrlEncodedContent(dict);
        using var response = client.SendAsync(req).Result;

        var dataContent = response.Content;
        var stringData = dataContent.ReadAsStringAsync().Result;
        var data = JsonConvert.DeserializeObject<AuthorizeResponse>(stringData);

        settings.Tempo.AccessToken = data.AccessToken;
        settings.Tempo.RefreshToken = data.RefreshToken;
        settings.Tempo.ExpiresIn = data.ExpiresIn;

        settings.Save();
    }
}