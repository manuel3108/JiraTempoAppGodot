﻿using Newtonsoft.Json;

namespace JiraTempoAppGodot.ApiModels.Jira;

public class AuthorizeResponse
{
    [JsonProperty("access_token")] public string AccessToken { get; set; }

    [JsonProperty("expires_in")] public int ExpiresIn { get; set; }

    [JsonProperty("token_type")] public string TokenType { get; set; }

    [JsonProperty("refresh_token")] public string RefreshToken { get; set; }

    [JsonProperty("scope")] public string Scope { get; set; }
}