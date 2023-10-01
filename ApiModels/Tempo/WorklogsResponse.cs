using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace JiraTempoAppGodot.ApiModels.Tempo;

public class WorklogsResponse
{
    [JsonProperty("metadata")] public MetadataClass Metadata { get; set; }

    [JsonProperty("results")] public List<Result> Results { get; set; }

    [JsonProperty("self")] public string Self { get; set; }

    public class Attributes
    {
        [JsonProperty("self")] public string Self { get; set; }

        [JsonProperty("values")] public List<Value> Values { get; set; }
    }

    public class Author
    {
        [JsonProperty("accountId")] public string AccountId { get; set; }

        [JsonProperty("self")] public string Self { get; set; }
    }

    public class Issue
    {
        [JsonProperty("id")] public int Id { get; set; }

        [JsonProperty("self")] public string Self { get; set; }
    }

    public class MetadataClass
    {
        [JsonProperty("count")] public int Count { get; set; }

        [JsonProperty("limit")] public int Limit { get; set; }

        [JsonProperty("next")] public string Next { get; set; }

        [JsonProperty("offset")] public int Offset { get; set; }

        [JsonProperty("previous")] public string Previous { get; set; }
    }

    public class Result
    {
        [JsonProperty("attributes")] public Attributes Attributes { get; set; }

        [JsonProperty("author")] public Author Author { get; set; }

        [JsonProperty("billableSeconds")] public int BillableSeconds { get; set; }

        [JsonProperty("createdAt")] public DateTime CreatedAt { get; set; }

        [JsonProperty("description")] public string Description { get; set; }

        [JsonProperty("issue")] public Issue Issue { get; set; }

        [JsonProperty("self")] public string Self { get; set; }

        [JsonProperty("startDate")] public string StartDate { get; set; }

        [JsonProperty("startTime")] public string StartTime { get; set; }

        [JsonProperty("tempoWorklogId")] public int TempoWorklogId { get; set; }

        [JsonProperty("timeSpentSeconds")] public int TimeSpentSeconds { get; set; }

        [JsonProperty("updatedAt")] public DateTime UpdatedAt { get; set; }
    }

    public class Value
    {
        [JsonProperty("key")] public string Key { get; set; }

        [JsonProperty("value")] public string ValueText { get; set; }
    }
}