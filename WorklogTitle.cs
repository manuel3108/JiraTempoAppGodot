using System.Linq;
using Godot;
using JiraTempoAppGodot.Services;

namespace JiraTempoAppGodot;

public partial class WorklogTitle : LineEdit
{
    private readonly JiraService _jiraService = ServiceCollection.Get<JiraService>();
    [Export] public NodePath IssueSelectionNodePath;

    public override void _Ready()
    {
        TextSubmitted += OnTextSubmitted;
    }

    private void OnTextSubmitted(string newText)
    {
        var selectionLabel = GetNode<Label>(IssueSelectionNodePath);

        var issues = _jiraService.SearchIssues(newText);

        var issueKeys1 = issues.Sections[0].Issues.Select(x => $"{x.Key} - {x.SummaryText}");
        var issueKeys2 = issues.Sections[1].Issues.Select(x => $"{x.Key} - {x.SummaryText}");
        var foundIssueKeys1 = string.Join(",\n", issueKeys1);
        var foundIssueKeys2 = string.Join(",\n", issueKeys2);
        var issueKeys = $"{foundIssueKeys1}\n\n\n{foundIssueKeys2}";
        selectionLabel.Text = issueKeys;
    }
}