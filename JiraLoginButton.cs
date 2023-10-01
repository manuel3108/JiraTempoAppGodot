using System.Linq;
using Godot;
using JiraTempoAppGodot.Services;

namespace JiraTempoAppGodot;

public partial class JiraLoginButton : Button
{
    private readonly JiraService _jiraService = ServiceCollection.Get<JiraService>();

    public override void _Pressed()
    {
        var authorizeResponse = _jiraService.ExecuteLogin();

        var settings = Settings.Load();
        settings.Jira.AccessToken = authorizeResponse.AccessToken;
        settings.Jira.RefreshToken = authorizeResponse.RefreshToken;
        settings.Jira.ExpiresIn = authorizeResponse.ExpiresIn;
        settings.Save();

        var availableResources = _jiraService.GetAccessibleResources();
        var firstResources = availableResources.First();

        settings.Jira.CloudId = firstResources.Id;
        settings.Jira.Domain = firstResources.Url;
        settings.Save();
    }
}