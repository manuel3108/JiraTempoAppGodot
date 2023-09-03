using System.Collections.Generic;
using Newtonsoft.Json;

namespace JiraTempoAppGodot.ApiModels.Jira;

public class AvailableResourcesResponse
{
    [JsonProperty("id")] public string Id { get; set; }

    [JsonProperty("url")] public string Url { get; set; }

    [JsonProperty("name")] public string Name { get; set; }

    [JsonProperty("scopes")] public List<string> Scopes { get; set; }

    [JsonProperty("avatarUrl")] public string AvatarUrl { get; set; }
}