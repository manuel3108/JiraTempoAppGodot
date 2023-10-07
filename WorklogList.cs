using Godot;

namespace JiraTempoAppGodot;

public partial class WorklogList : VBoxContainer
{
    [Export] public NodePath AddWorklogButtonNodePath;

    public override void _Ready()
    {
        var button = GetNode<Button>(AddWorklogButtonNodePath);
        button.Pressed += AddNewWorklog;
    }

    private void AddNewWorklog()
    {
        var scene = GD.Load<PackedScene>("res://Worklog.tscn");
        var timeEntry = scene.Instantiate();

        AddChild(timeEntry);
    }
}