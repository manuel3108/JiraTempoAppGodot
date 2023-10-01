using System.Collections.Generic;
using Newtonsoft.Json;

namespace JiraTempoAppGodot.ApiModels.Tempo;

public class AccountsResponse
{
    [JsonProperty("metadata")] public MetadataClass Metadata { get; set; }

    [JsonProperty("results")] public List<Result> Results { get; set; }

    [JsonProperty("self")] public string Self { get; set; }

    public class Category
    {
        [JsonProperty("id")] public int Id { get; set; }

        [JsonProperty("key")] public string Key { get; set; }

        [JsonProperty("name")] public string Name { get; set; }

        [JsonProperty("self")] public string Self { get; set; }

        [JsonProperty("type")] public Type Type { get; set; }
    }

    public class Contact
    {
        [JsonProperty("accountId")] public string AccountId { get; set; }

        [JsonProperty("self")] public string Self { get; set; }

        [JsonProperty("type")] public string TypeText { get; set; }
    }

    public class Customer
    {
        [JsonProperty("id")] public int Id { get; set; }

        [JsonProperty("key")] public string Key { get; set; }

        [JsonProperty("name")] public string Name { get; set; }

        [JsonProperty("self")] public string Self { get; set; }
    }

    public class Links
    {
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
        [JsonProperty("category")] public Category Category { get; set; }

        [JsonProperty("contact")] public Contact Contact { get; set; }

        [JsonProperty("customer")] public Customer Customer { get; set; }

        [JsonProperty("global")] public bool Global { get; set; }

        [JsonProperty("id")] public int Id { get; set; }

        [JsonProperty("key")] public string Key { get; set; }

        [JsonProperty("lead")] public string Lead { get; set; }

        [JsonProperty("links")] public Links Links { get; set; }

        [JsonProperty("monthlyBudget")] public int MonthlyBudget { get; set; }

        [JsonProperty("name")] public string Name { get; set; }

        [JsonProperty("self")] public string Self { get; set; }

        [JsonProperty("status")] public string Status { get; set; }
    }

    public class Type
    {
        [JsonProperty("name")] public string Name { get; set; }
    }
}