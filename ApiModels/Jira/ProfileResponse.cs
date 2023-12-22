using System.Collections.Generic;
using Newtonsoft.Json;

namespace JiraTempoAppGodot.ApiModels.Jira;

public class ProfileResponse
{
    [JsonProperty("self")] public string Self { get; set; }

    [JsonProperty("accountId")] public string AccountId { get; set; }

    [JsonProperty("accountType")] public string AccountType { get; set; }

    [JsonProperty("emailAddress")] public string EmailAddress { get; set; }

    [JsonProperty("avatarUrls")] public AvatarUrlsData AvatarUrls { get; set; }

    [JsonProperty("displayName")] public string DisplayName { get; set; }

    [JsonProperty("active")] public bool Active { get; set; }

    [JsonProperty("timeZone")] public string TimeZone { get; set; }

    [JsonProperty("locale")] public string Locale { get; set; }

    [JsonProperty("groups")] public GroupsData Groups { get; set; }

    [JsonProperty("applicationRoles")] public ApplicationRolesData ApplicationRoles { get; set; }

    [JsonProperty("expand")] public string Expand { get; set; }

    public class ApplicationRolesData
    {
        [JsonProperty("size")] public int Size { get; set; }

        [JsonProperty("items")] public List<object> Items { get; set; }
    }

    public class AvatarUrlsData
    {
        [JsonProperty("48x48")] public string _48x48 { get; set; }

        [JsonProperty("24x24")] public string _24x24 { get; set; }

        [JsonProperty("16x16")] public string _16x16 { get; set; }

        [JsonProperty("32x32")] public string _32x32 { get; set; }
    }

    public class GroupsData
    {
        [JsonProperty("size")] public int Size { get; set; }

        [JsonProperty("items")] public List<object> Items { get; set; }
    }
}