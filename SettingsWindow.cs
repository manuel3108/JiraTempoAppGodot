using Godot;

namespace JiraTempoAppGodot;

public partial class SettingsWindow : PanelContainer
{
    [Export] public NodePath CloseWindowButtonNodePath;
    [Export] public NodePath JiraAccessTokenNodePath;
    [Export] public NodePath JiraClientIdNodePath;
    [Export] public NodePath JiraClientSecretNodePath;
    [Export] public NodePath JiraCloudIdNodePath;
    [Export] public NodePath JiraDomainNodePath;
    [Export] public NodePath JiraExpiresInNodePath;
    [Export] public NodePath JiraRefreshTokenNodePath;
    [Export] public NodePath TempoAccessTokenNodePath;
    [Export] public NodePath TempoClientIdNodePath;
    [Export] public NodePath TempoClientSecretNodePath;
    [Export] public NodePath TempoExpiresInNodePath;
    [Export] public NodePath TempoRefreshTokenNodePath;

    public override void _Ready()
    {
        VisibilityChanged += OnVisibilityChanged;

        var node = GetNode<Button>(CloseWindowButtonNodePath);
        node.Pressed += CloseWindow;
    }

    private void CloseWindow()
    {
        Visible = false;
    }

    private void OnVisibilityChanged()
    {
        var settings = Settings.Load();

        if (Visible)
        {
            // load settings
            SetLineEditValue(JiraClientIdNodePath, settings.Jira.ClientId);
            SetLineEditValue(JiraClientSecretNodePath, settings.Jira.ClientSecret);
            SetLineEditValue(JiraAccessTokenNodePath, settings.Jira.AccessToken);
            SetLineEditValue(JiraRefreshTokenNodePath, settings.Jira.RefreshToken);
            SetLineEditValue(JiraExpiresInNodePath, settings.Jira.ExpiresIn.ToString());
            SetLineEditValue(JiraCloudIdNodePath, settings.Jira.CloudId);
            SetLineEditValue(JiraDomainNodePath, settings.Jira.Domain);

            SetLineEditValue(TempoClientIdNodePath, settings.Tempo.ClientId);
            SetLineEditValue(TempoClientSecretNodePath, settings.Tempo.ClientSecret);
            SetLineEditValue(TempoAccessTokenNodePath, settings.Tempo.AccessToken);
            SetLineEditValue(TempoRefreshTokenNodePath, settings.Tempo.RefreshToken);
            SetLineEditValue(TempoExpiresInNodePath, settings.Tempo.ExpiresIn.ToString());
        }
        else
        {
            // save settings
            settings.Jira.ClientId = GetLineEditValue(JiraClientIdNodePath);
            settings.Jira.ClientSecret = GetLineEditValue(JiraClientSecretNodePath);
            settings.Tempo.ClientId = GetLineEditValue(TempoClientIdNodePath);
            settings.Tempo.ClientSecret = GetLineEditValue(TempoClientSecretNodePath);

            settings.Save();
        }
    }

    private void SetLineEditValue(NodePath nodePath, string text)
    {
        var node = GetNode<LineEdit>(nodePath);
        node.Text = text;
    }

    private string GetLineEditValue(NodePath nodePath)
    {
        var node = GetNode<LineEdit>(nodePath);
        return node.Text;
    }
}