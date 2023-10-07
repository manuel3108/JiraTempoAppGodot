using Godot;

public partial class Worklog : PanelContainer
{
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
}