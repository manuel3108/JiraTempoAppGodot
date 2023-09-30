using Godot;
using JiraTempoAppGodot;

public partial class SettingsWindow : PanelContainer
{
    [Export] public NodePath CloseWindowButtonNodePath;
    [Export] public NodePath JiraClientIdNodePath;
    [Export] public NodePath JiraClientSecretNodePath;
    [Export] public NodePath TempoClientIdNodePath;
    [Export] public NodePath TempoClientSecretNodePath;

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
            SetLineEditValue(TempoClientIdNodePath, settings.Tempo.ClientId);
            SetLineEditValue(TempoClientSecretNodePath, settings.Tempo.ClientSecret);
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