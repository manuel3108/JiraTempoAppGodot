using Godot;
using JiraTempoAppGodot.Services;

namespace JiraTempoAppGodot;

public partial class Worklog : PanelContainer
{
    private readonly TempoService _tempoService = ServiceCollection.Get<TempoService>();
    [Export] public NodePath AccountOptionButtonNodePath;
    [Export] public NodePath AddTimeEntryButtonNodePath;
    [Export] public NodePath TimeEntriesContainerNodePath;

    public override void _Ready()
    {
        var addTimeEntryButton = GetNode<Button>(AddTimeEntryButtonNodePath);
        addTimeEntryButton.Pressed += AddNewTimeEntryRow;
    }

    private void AddNewTimeEntryRow()
    {
        var container = GetNode<Container>(TimeEntriesContainerNodePath);
        var scene = GD.Load<PackedScene>("res://TimeEntry.tscn");
        var timeEntry = scene.Instantiate();
        container.AddChild(timeEntry);
    }

    public void IssueSelected()
    {
        GD.Print("Worklog: Issue selected");
        var accountResults = _tempoService.GetAccounts();

        var accountOptionButton = GetNode<OptionButton>(AccountOptionButtonNodePath);
        foreach (var account in accountResults.Results) accountOptionButton.AddItem(account.Name, account.Id);
    }
}