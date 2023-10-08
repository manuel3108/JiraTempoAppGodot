using Godot;
using JiraTempoAppGodot.Services;

namespace JiraTempoAppGodot;

public partial class WorklogTitle : LineEdit
{
    private readonly JiraService _jiraService = ServiceCollection.Get<JiraService>();
    [Export] public NodePath IssueSelectionPanelNodePath;

    public override void _Ready()
    {
        TextSubmitted += OnTextSubmitted;
    }

    private void OnTextSubmitted(string newText)
    {
        var selectionPanel = GetNode<IssueSelection>(IssueSelectionPanelNodePath);
        selectionPanel.Show();

        var issues = _jiraService.SearchIssues(Text);
        selectionPanel.SetIssues(issues);
    }
}