using Godot;

namespace JiraTempoAppGodot;

public partial class TimeEntry : HBoxContainer
{
    [Export] public NodePath StartLineEditNode { get; set; }
    [Export] public NodePath EndLineEditNode { get; set; }

    public override void _Ready()
    {
        var startLineEdit = GetNode<LineEdit>(StartLineEditNode);
        startLineEdit.TextChanged += OnTextChanged;
    }

    private void OnTextChanged(string newtext)
    {
        GD.Print(newtext);
    }
}