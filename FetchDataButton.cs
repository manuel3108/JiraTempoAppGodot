using System.Linq;
using System.Net.Http.Headers;
using Godot;
using JiraTempoAppGodot;
using JiraTempoAppGodot.ApiModels.Jira;
using Newtonsoft.Json;
using HttpClient = System.Net.Http.HttpClient;

public partial class FetchDataButton : Button
{
    [Export] public NodePath LabelPath { get; set; }
    [Export] public NodePath SearchTextEditPath { get; set; }

    // Called when the node enters the scene tree for the first time.
    public override void _Pressed()
    {
        var settings = Settings.Load();
        var baseUrl = $"https://api.atlassian.com/ex/jira/{settings.Jira.CloudId}/";

        var searchNode = GetNode<LineEdit>(SearchTextEditPath);
        var query = searchNode.Text;

        var httpClient = new HttpClient();
        httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", settings.Jira.AccessToken);
        var response = httpClient.GetAsync($"{baseUrl}rest/api/3/issue/picker?query={query}&currentJQL=").Result;
        var dataContent = response.Content;
        var stringData = dataContent.ReadAsStringAsync().Result;
        var data = JsonConvert.DeserializeObject<SearchIssuesResponse>(stringData);

        // TODO hard coded index
        var issueKeys = data.Sections[0].Issues.Select(x => $"{x.Key} - {x.SummaryText}");
        var foundIssueKeys = string.Join(",\n", issueKeys);

        var label = GetNode<Label>(LabelPath);
        label.Text = foundIssueKeys;

        // var tempoClient = new TempoClient(new HttpClient());
        // tempoClient.
        // var test = tempoClient.GetWorklogsAsync(null, null, "2021-09-29", "2023-09-29", "2021-09-29", null, null, null).Result;

        httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", settings.Tempo.AccessToken);
        var tempoUrl = "https://api.tempo.io/4/worklogs?from=2022-01-28&to=2024-02-03";
        response = httpClient.GetAsync(tempoUrl).Result;
        dataContent = response.Content;
        stringData = dataContent.ReadAsStringAsync().Result;
        GD.Print(stringData);
    }
}