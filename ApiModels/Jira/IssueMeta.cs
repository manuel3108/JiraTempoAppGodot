using System.Collections.Generic;
using Newtonsoft.Json;

namespace JiraTempoAppGodot.ApiModels.Jira;

public class IssueMeta
{
    [JsonProperty("fields")] public Dictionary<string, FieldMeta> Fields { get; set; }

    public class FieldMeta
    {
        public bool Required { get; set; }
        public Schema Schema { get; set; }
        public string Name { get; set; }
        public string Key { get; set; }
        public string AutoCompleteUrl { get; set; }
        public string[] Operations { get; set; }
    }

    public class Schema
    {
        public string Type { get; set; }
        public string Items { get; set; }
        public string System { get; set; }
    }
}