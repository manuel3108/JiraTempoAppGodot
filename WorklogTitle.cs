using Godot;
using JiraTempoAppGodot.Events;
using JiraTempoAppGodot.Services;

namespace JiraTempoAppGodot;

public partial class WorklogTitle : LineEdit
{
    private readonly JiraService _jiraService = ServiceCollection.Get<JiraService>();
    private IssueSelection _selectionPanel;
    private Worklog _worklogPanel;
    [Export] public NodePath IssueSelectionPanelNodePath;
    [Export] public NodePath WorklogPanelNodePath;

    public override void _Ready()
    {
        TextSubmitted += OnTextSubmitted;

        _selectionPanel = GetNode<IssueSelection>(IssueSelectionPanelNodePath);
        _selectionPanel.IssueSelectedEvent += OnIssueSelected;

        _worklogPanel = GetNode<Worklog>(WorklogPanelNodePath);
    }

    private void OnIssueSelected(object sender, IssueSelectedEventArgs e)
    {
        Text = $"{e.Key} - {e.Title}";
        _selectionPanel.Hide();
        GrabFocus();

        _worklogPanel.IssueSelected(e.Id);
    }

    private void OnTextSubmitted(string newText)
    {
        _selectionPanel.Show();

        var issues = _jiraService.SearchIssues(Text);
        _selectionPanel.SetIssues(issues);
    }
}