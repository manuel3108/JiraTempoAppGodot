using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using Godot;
using JiraTempoAppGodot;
using JiraTempoAppGodot.ApiModels.Jira;
using Newtonsoft.Json;
using HttpClient = System.Net.Http.HttpClient;

public partial class JiraLoginButton : Button
{
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
    }

    public override void _Pressed()
    {
        var redirectUrl = UrlCallbackServer.CallbackUrl;
        var url =
            $"https://auth.atlassian.com/authorize?audience=api.atlassian.com&client_id={Main.JIRA_CLIENT_ID}&scope=read%3Ajira-work%20read%3Ajira-user%20read%3Aissue-details%3Ajira%20offline_access&redirect_uri={redirectUrl}&state=YOUR_USER_BOUND_VALUE&response_type=code&prompt=consent";
        OS.ShellOpen(url);

        var code = UrlCallbackServer.WaitAndGetCodeFromQueryParam();
        GD.Print(code);

        var authRequest = new AuthorizeRequest
        {
            Code = code,
            ClientId = Main.JIRA_CLIENT_ID,
            ClientSecret = Main.JIRA_CLIENT_SECRET,
            GrantType = "authorization_code",
            RedirectUri = UrlCallbackServer.CallbackUrl
        };
        var httpClient = new HttpClient();
        var httpContent = new StringContent(JsonConvert.SerializeObject(authRequest));
        httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        var response = httpClient.PostAsync("https://auth.atlassian.com/oauth/token", httpContent).Result;
        var dataContent = response.Content;
        var stringData = dataContent.ReadAsStringAsync().Result;

        var data = JsonConvert.DeserializeObject<AuthorizeResponse>(stringData);

        var settings = Settings.Load();
        settings.Jira.AccessToken = data.AccessToken;
        settings.Jira.RefreshToken = data.RefreshToken;
        settings.Jira.ExpiresIn = data.ExpiresIn;
        settings.Save();

        httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", settings.Jira.AccessToken);
        response = httpClient.GetAsync("https://api.atlassian.com/oauth/token/accessible-resources").Result;
        dataContent = response.Content;
        stringData = dataContent.ReadAsStringAsync().Result;
        var data2 = JsonConvert.DeserializeObject<List<AvailableResourcesResponse>>(stringData);

        settings.Jira.CloudId = data2.First().Id;
        settings.Save();
    }
}