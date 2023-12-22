using System.Collections.Generic;
using Newtonsoft.Json;

namespace JiraTempoAppGodot.ApiModels.Tempo;

public class CreateWorklogRequest
{
    [JsonProperty("attributes")] public List<Attribute> Attributes { get; set; }

    [JsonProperty("authorAccountId")] public string AuthorAccountId { get; set; }

    [JsonProperty("billableSeconds")] public int BillableSeconds { get; set; }

    [JsonProperty("description")] public string Description { get; set; }

    [JsonProperty("issueId")] public int IssueId { get; set; }

    [JsonProperty("remainingEstimateSeconds")]
    public int RemainingEstimateSeconds { get; set; }

    [JsonProperty("startDate")] public string StartDate { get; set; }

    [JsonProperty("startTime")] public string StartTime { get; set; }

    [JsonProperty("timeSpentSeconds")] public int TimeSpentSeconds { get; set; }

    public class Attribute
    {
        [JsonProperty("key")] public string Key { get; set; }

        [JsonProperty("value")] public string Value { get; set; }
    }
}