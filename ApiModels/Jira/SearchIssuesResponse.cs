using System.Collections.Generic;
using Newtonsoft.Json;

namespace JiraTempoAppGodot.ApiModels.Jira;

public class SearchIssuesResponse
{
    [JsonProperty("sections")] public List<Section> Sections { get; set; }

    public class Issue
    {
        [JsonProperty("id")] public int Id { get; set; }

        [JsonProperty("key")] public string Key { get; set; }

        [JsonProperty("keyHtml")] public string KeyHtml { get; set; }

        [JsonProperty("img")] public string Img { get; set; }

        [JsonProperty("summary")] public string Summary { get; set; }

        [JsonProperty("summaryText")] public string SummaryText { get; set; }
    }

    public class Section
    {
        [JsonProperty("label")] public string Label { get; set; }

        [JsonProperty("id")] public string Id { get; set; }

        [JsonProperty("msg")] public string Msg { get; set; }

        [JsonProperty("issues")] public List<Issue> Issues { get; set; }

        [JsonProperty("sub")] public string Sub { get; set; }
    }
}