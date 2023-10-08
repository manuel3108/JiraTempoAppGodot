using System;
using System.Collections.Generic;
using Godot;
using JiraTempoAppGodot;
using JiraTempoAppGodot.ApiModels.Jira;

public partial class IssueSelection : PanelContainer
{
    [Export] public NodePath FullSearchContainerNodePath;
    [Export] public NodePath HistorySearchContainerNodePath;

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
            issueSelectionEntry.MyEvent += OnEventHappend;
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

    private void OnEventHappend(object sender, EventArgs e)
    {
        GD.Print("MyEvent");
    }
}