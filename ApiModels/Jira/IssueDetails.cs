using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace JiraTempoAppGodot.ApiModels.Jira;

public class IssueDetails
{
    [JsonProperty("expand")] public string Expand { get; set; }

    [JsonProperty("id")] public string Id { get; set; }

    [JsonProperty("self")] public string Self { get; set; }

    [JsonProperty("key")] public string Key { get; set; }

    [JsonProperty("fields")] public Dictionary<string, object> FieldsData { get; set; }

    public class Aggregateprogress
    {
        [JsonProperty("progress")] public int Progress { get; set; }

        [JsonProperty("total")] public int Total { get; set; }

        [JsonProperty("percent")] public int Percent { get; set; }
    }

    public class Author
    {
        [JsonProperty("self")] public string Self { get; set; }

        [JsonProperty("accountId")] public string AccountId { get; set; }

        [JsonProperty("avatarUrls")] public AvatarUrls AvatarUrls { get; set; }

        [JsonProperty("displayName")] public string DisplayName { get; set; }

        [JsonProperty("active")] public bool Active { get; set; }

        [JsonProperty("timeZone")] public string TimeZone { get; set; }

        [JsonProperty("accountType")] public string AccountType { get; set; }
    }

    public class AvatarUrls
    {
        [JsonProperty("48x48")] public string _48x48 { get; set; }

        [JsonProperty("24x24")] public string _24x24 { get; set; }

        [JsonProperty("16x16")] public string _16x16 { get; set; }

        [JsonProperty("32x32")] public string _32x32 { get; set; }
    }

    public class Comment
    {
        [JsonProperty("comments")] public List<object> Comments { get; set; }

        [JsonProperty("self")] public string Self { get; set; }

        [JsonProperty("maxResults")] public int MaxResults { get; set; }

        [JsonProperty("total")] public int Total { get; set; }

        [JsonProperty("startAt")] public int StartAt { get; set; }

        [JsonProperty("version")] public int Version { get; set; }

        [JsonProperty("type")] public string Type { get; set; }

        [JsonProperty("content")] public List<Content> Content { get; set; }
    }

    public class Content
    {
        [JsonProperty("type")] public string Type { get; set; }

        [JsonProperty("content")] public List<Content> ContentData { get; set; }

        [JsonProperty("text")] public string Text { get; set; }
    }

    public class Creator
    {
        [JsonProperty("self")] public string Self { get; set; }

        [JsonProperty("accountId")] public string AccountId { get; set; }

        [JsonProperty("emailAddress")] public string EmailAddress { get; set; }

        [JsonProperty("avatarUrls")] public AvatarUrls AvatarUrls { get; set; }

        [JsonProperty("displayName")] public string DisplayName { get; set; }

        [JsonProperty("active")] public bool Active { get; set; }

        [JsonProperty("timeZone")] public string TimeZone { get; set; }

        [JsonProperty("accountType")] public string AccountType { get; set; }
    }


    public class NonEditableReason
    {
        [JsonProperty("reason")] public string Reason { get; set; }

        [JsonProperty("message")] public string Message { get; set; }
    }

    public class Priority
    {
        [JsonProperty("self")] public string Self { get; set; }

        [JsonProperty("iconUrl")] public string IconUrl { get; set; }

        [JsonProperty("name")] public string Name { get; set; }

        [JsonProperty("id")] public string Id { get; set; }
    }

    public class Progress
    {
        [JsonProperty("progress")] public int ProgressData { get; set; }

        [JsonProperty("total")] public int Total { get; set; }

        [JsonProperty("percent")] public int Percent { get; set; }
    }

    public class Project
    {
        [JsonProperty("self")] public string Self { get; set; }

        [JsonProperty("id")] public string Id { get; set; }

        [JsonProperty("key")] public string Key { get; set; }

        [JsonProperty("name")] public string Name { get; set; }

        [JsonProperty("projectTypeKey")] public string ProjectTypeKey { get; set; }

        [JsonProperty("simplified")] public bool Simplified { get; set; }

        [JsonProperty("avatarUrls")] public AvatarUrls AvatarUrls { get; set; }
    }

    public class Reporter
    {
        [JsonProperty("self")] public string Self { get; set; }

        [JsonProperty("accountId")] public string AccountId { get; set; }

        [JsonProperty("emailAddress")] public string EmailAddress { get; set; }

        [JsonProperty("avatarUrls")] public AvatarUrls AvatarUrls { get; set; }

        [JsonProperty("displayName")] public string DisplayName { get; set; }

        [JsonProperty("active")] public bool Active { get; set; }

        [JsonProperty("timeZone")] public string TimeZone { get; set; }

        [JsonProperty("accountType")] public string AccountType { get; set; }
    }

    public class Status
    {
        [JsonProperty("self")] public string Self { get; set; }

        [JsonProperty("description")] public string Description { get; set; }

        [JsonProperty("iconUrl")] public string IconUrl { get; set; }

        [JsonProperty("name")] public string Name { get; set; }

        [JsonProperty("id")] public string Id { get; set; }

        [JsonProperty("statusCategory")] public StatusCategory StatusCategory { get; set; }
    }

    public class StatusCategory
    {
        [JsonProperty("self")] public string Self { get; set; }

        [JsonProperty("id")] public int Id { get; set; }

        [JsonProperty("key")] public string Key { get; set; }

        [JsonProperty("colorName")] public string ColorName { get; set; }

        [JsonProperty("name")] public string Name { get; set; }
    }

    public class UpdateAuthor
    {
        [JsonProperty("self")] public string Self { get; set; }

        [JsonProperty("accountId")] public string AccountId { get; set; }

        [JsonProperty("avatarUrls")] public AvatarUrls AvatarUrls { get; set; }

        [JsonProperty("displayName")] public string DisplayName { get; set; }

        [JsonProperty("active")] public bool Active { get; set; }

        [JsonProperty("timeZone")] public string TimeZone { get; set; }

        [JsonProperty("accountType")] public string AccountType { get; set; }
    }

    public class Votes
    {
        [JsonProperty("self")] public string Self { get; set; }

        [JsonProperty("votes")] public int VotesData { get; set; }

        [JsonProperty("hasVoted")] public bool HasVoted { get; set; }
    }

    public class Watches
    {
        [JsonProperty("self")] public string Self { get; set; }

        [JsonProperty("watchCount")] public int WatchCount { get; set; }

        [JsonProperty("isWatching")] public bool IsWatching { get; set; }
    }

    public class Worklog
    {
        [JsonProperty("startAt")] public int StartAt { get; set; }

        [JsonProperty("maxResults")] public int MaxResults { get; set; }

        [JsonProperty("total")] public int Total { get; set; }

        [JsonProperty("worklogs")] public List<Worklog2> Worklogs { get; set; }
    }

    public class Worklog2
    {
        [JsonProperty("self")] public string Self { get; set; }

        [JsonProperty("author")] public Author Author { get; set; }

        [JsonProperty("updateAuthor")] public UpdateAuthor UpdateAuthor { get; set; }

        [JsonProperty("comment")] public Comment Comment { get; set; }

        [JsonProperty("created")] public DateTime Created { get; set; }

        [JsonProperty("updated")] public DateTime Updated { get; set; }

        [JsonProperty("started")] public DateTime Started { get; set; }

        [JsonProperty("timeSpent")] public string TimeSpent { get; set; }

        [JsonProperty("timeSpentSeconds")] public int TimeSpentSeconds { get; set; }

        [JsonProperty("id")] public string Id { get; set; }

        [JsonProperty("issueId")] public string IssueId { get; set; }
    }
}