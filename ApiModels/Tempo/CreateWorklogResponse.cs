using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace JiraTempoAppGodot.ApiModels.Tempo;

public class CreateWorklogResponse
{
    [JsonProperty("attributes")] public AttributesList Attributes { get; set; }

    [JsonProperty("author")] public AuthorData Author { get; set; }

    [JsonProperty("billableSeconds")] public int BillableSeconds { get; set; }

    [JsonProperty("createdAt")] public DateTime CreatedAt { get; set; }

    [JsonProperty("description")] public string Description { get; set; }

    [JsonProperty("issue")] public IssueData Issue { get; set; }

    [JsonProperty("self")] public string Self { get; set; }

    [JsonProperty("startDate")] public string StartDate { get; set; }

    [JsonProperty("startTime")] public string StartTime { get; set; }

    [JsonProperty("tempoWorklogId")] public int TempoWorklogId { get; set; }

    [JsonProperty("timeSpentSeconds")] public int TimeSpentSeconds { get; set; }

    [JsonProperty("updatedAt")] public DateTime UpdatedAt { get; set; }

    public class AttributesList
    {
        [JsonProperty("self")] public string Self { get; set; }

        [JsonProperty("values")] public List<object> Values { get; set; }
    }

    public class AuthorData
    {
        [JsonProperty("accountId")] public string AccountId { get; set; }

        [JsonProperty("self")] public string Self { get; set; }
    }

    public class IssueData
    {
        [JsonProperty("id")] public int Id { get; set; }

        [JsonProperty("self")] public string Self { get; set; }
    }
}