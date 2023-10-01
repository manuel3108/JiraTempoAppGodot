using System.Linq;
using Godot;
using JiraTempoAppGodot.Services;
using Newtonsoft.Json;

namespace JiraTempoAppGodot;

public partial class FetchDataButton : Button
{
    private readonly JiraService _jiraService = ServiceCollection.Get<JiraService>();
    private readonly TempoService _tempoService = ServiceCollection.Get<TempoService>();
    [Export] public NodePath LabelPath { get; set; }
    [Export] public NodePath SearchTextEditPath { get; set; }

    // Called when the node enters the scene tree for the first time.
    public override void _Pressed()
    {
        var searchNode = GetNode<LineEdit>(SearchTextEditPath);
        var query = searchNode.Text;

        var data = _jiraService.SearchIssues(query);
        // TODO hard coded index
        var issueKeys = data.Sections[0].Issues.Select(x => $"{x.Key} - {x.SummaryText}");
        var foundIssueKeys = string.Join(",\n", issueKeys);

        var label = GetNode<Label>(LabelPath);
        label.Text = foundIssueKeys;

        var worklogs = _tempoService.GetWorklogs();
        GD.Print(JsonConvert.SerializeObject(worklogs));

        var accounts = _tempoService.GetAccounts();
        GD.Print(JsonConvert.SerializeObject(accounts));
    }
}