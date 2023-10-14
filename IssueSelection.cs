using System;
using System.Collections.Generic;
using Godot;
using JiraTempoAppGodot;
using JiraTempoAppGodot.ApiModels.Jira;
using JiraTempoAppGodot.Events;

public partial class IssueSelection : PanelContainer
{
    [Export] public NodePath FullSearchContainerNodePath;
    [Export] public NodePath HistorySearchContainerNodePath;
    public event EventHandler<IssueSelectedEventArgs> IssueSelectedEvent;

    public override void _Ready()
    {
    }

    public void SetIssues(SearchIssuesResponse issuesData)
    {
        var data = new List<(NodePath containerPath, List<SearchIssuesResponse.Issue>)>
        {
            (HistorySearchContainerNodePath, issuesData.Sections[0].Issues),
            (FullSearchContainerNodePath, issuesData.Sections[1].Issues)
        };

        var isFirst = true;
        foreach (var (containerPath, issues) in data)
        foreach (var issue in issues)
        {
            var container = GetNode<Container>(containerPath);

            var scene = GD.Load<PackedScene>("res://IssueSelectionEntry.tscn");
            var issueSelectionEntry = scene.Instantiate<IssueSelectionEntry>();
            issueSelectionEntry.IssueSelectedEvent += OnIssueSelected;
            var textLabel = issueSelectionEntry.GetChild<Label>(0);
            textLabel.Text = $"{issue.Key}: {issue.SummaryText}";
            container.AddChild(issueSelectionEntry);
            issueSelectionEntry.SetData(issue.Key, issue.SummaryText);

            if (isFirst)
            {
                var button = issueSelectionEntry.GetChild<Button>(1);
                button.GrabFocus();
                isFirst = false;
            }
        }
    }

    private void OnIssueSelected(object sender, IssueSelectedEventArgs e)
    {
        if (IssueSelectedEvent is not null) IssueSelectedEvent(sender, e);
    }
}